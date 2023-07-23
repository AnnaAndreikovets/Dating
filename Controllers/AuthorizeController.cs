using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;

namespace DatingSite.Controllers
{
    public class AuthorizeController : Controller
    {
        readonly IPeople people;

        public AuthorizeController(IPeople people)
        {
            this.people = people;
        }

        [HttpGet]
        [Route("Authorize/LogIn")]
        public IActionResult LogIn()
        {
            return View();
        }
        
        [HttpGet]
        [Route("Authorize/SignIn")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [Route("Authorize/LogInEnter")]
        public async Task<IActionResult> LogInEnter()
        {
            var form = HttpContext.Request.Form;

            if (!form.ContainsKey("email") || !form.ContainsKey("password")) return RedirectToAction("LogIn"); //уведомить, что данные для входа не заданы
 
            string email = form["email"]!;
            string password = form["password"]!;
            if(people is null)
            {
                throw new NullReferenceException();
            }

            User? user = people!.Users()?.FirstOrDefault(p => p.Email == email);
            
            if (user is not null) return RedirectToAction("LogIn"); //уведомить, что такой пользователь уже существует

            if (!form.ContainsKey("firstName") || !form.ContainsKey("secondName")  || !form.ContainsKey("age") || form.Files.GetFile("photo") is null || 
            !form.ContainsKey("description") || !form.ContainsKey("sex") || !form.ContainsKey("preferSex")) return RedirectToAction("LogIn"); //уведомить, что данные не заданы

            string firstName = form["firstName"]!;
            string secondName = form["secondName"]!;
            string description = form["description"]!;
            string sex = form["sex"]!;
            string preferSex = form["preferSex"]!;
            Byte.TryParse(form["age"], out byte age);
            var photo = form.Files.GetFile("photo")!;
            
            var newFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img");
            string imagePath = Path.Combine(directoryPath, newFileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                photo.CopyTo(stream);
            }

            imagePath = Path.Combine("/images", newFileName);

            Blank blank = new Blank()
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                SecondName = secondName,
                Age = age,
                Photo = $"/img/{newFileName}",
                Description = description,
                Sex = sex,
                PreferSex = preferSex
            };
            user = new User()
            {
                Id = Guid.NewGuid(),
                BlankId = blank.Id,
                Email = email,
                Password = password
            };
            Interaction interaction = new Interaction()
            {
                Id = Guid.NewGuid(),
                UserId = user.Id
            };
            Interested interested = new Interested()
            {
                Id = Guid.NewGuid(),
                UserId = user.Id
            };
            
            people.AddInterested(interested);
            people.AddInteractions(interaction);
            people.AddBlank(blank);
            people.AddUser(user);

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Email) };
            
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));

            return RedirectPermanent("/Home/Index");
        }

        [HttpPost]
        [Route("Authorize/SignInEnter")]
        public async Task<IActionResult> SignInEnter()
        {
            var form = HttpContext.Request.Form;
            
            if (!form.ContainsKey("email") || !form.ContainsKey("password")) return RedirectToAction("SignIn"); //уведомить, что данные незаданы
 
            string email = form["email"]!;
            string password = form["password"]!;

            User? user = people?.Users()?.FirstOrDefault(p => p.Email == email && p.Password == password);
            
            if (user is null) return RedirectToAction("SignIn"); //уведомить, что неверные данные
            
            people!.SetUser(user);

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Email) };
            
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));

            return RedirectPermanent("/Home/Index");
        }

        [Route("Authorize/LogOut")]
        public async Task<IActionResult> LogOut()
        {
            people.SetUser(new User());

            await HttpContext.SignOutAsync("Cookies");

            return View();
        }
    }
}