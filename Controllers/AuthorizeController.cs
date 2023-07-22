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
            
            if (!form.ContainsKey("firstName") || !form.ContainsKey("secondName")  || !form.ContainsKey("years") || !form.ContainsKey("photo") || 
            !form.ContainsKey("description") || !form.ContainsKey("sex") || !form.ContainsKey("preferSex")) return RedirectToAction("LogIn"); //уведомить, что данные не заданы
            
            string firstName = form["firstName"]!;
            string secondName = form["secondName"]!;
            string photo = form["photo"]!;
            string description = form["description"]!;
            string sex = form["sex"]!;
            string preferSex = form["preferSex"]!;
            Byte.TryParse(form["years"], out byte years);

            //добавть в wwwroot/img изображение

            Blank blank = new Blank()
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                SecondName = secondName,
                Years = years,
                Photo = photo,
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

            return RedirectToAction("CreateAccount");
        }

        [HttpPost]
        public async Task<IActionResult> SignInEnter()
        {
            var form = HttpContext.Request.Form;
            
            if (!form.ContainsKey("email") || !form.ContainsKey("password")) return RedirectToAction("SignIn"); //уведомить, что данные незаданы
 
            string email = form["email"]!;
            string password = form["password"]!;

            User? person = people?.Users()?.FirstOrDefault(p => p.Email == email && p.Password == password);
            
            if (person is null) return RedirectToAction("SignIn"); //уведомить, что неверные данные
            
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Email) };
            
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync("Cookies");

            return RedirectToAction("Login");
        }
    }
}