using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using DatingSite.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        public IActionResult LogIn()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogInEnter()
        {
            var form = HttpContext.Request.Form;

            if (!form.ContainsKey("email") || !form.ContainsKey("password"))
            {
                return RedirectToAction("LogIn");
            }
 
            string email = form["email"]!;
            string password = form["password"]!;

            User? user = people!.User(email);
            
            if (user is not null)
            {
                ViewData["information"] = "User already exists";
                return View("LogIn");
            }

            if (!form.ContainsKey("firstName") || !form.ContainsKey("secondName")  || !form.ContainsKey("age") || form.Files.GetFile("photo") is null || !form.ContainsKey("description") || !form.ContainsKey("sex") || !form.ContainsKey("preferSex"))
            {
                return RedirectToAction("LogIn");
            }

            string firstName = form["firstName"]!;
            string secondName = form["secondName"]!;
            string description = form["description"]!;
            string sex = form["sex"]!;
            string preferSex = form["preferSex"]!;
            string? rememberMe = form["rememberMe"];
            Byte.TryParse(form["age"], out byte age);
            var photo = form.Files.GetFile("photo")!;
            
            var newFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);
            string imagePath = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img"), newFileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                photo.CopyTo(stream);
            }

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
            
            await people.AddInterested(interested);
            await people.AddInteractions(interaction);
            await people.AddBlank(blank);
            await people.AddUser(user);

            AddRemeberMe(rememberMe, password, email);

            return await AddCookies(user.Email);
        }

        [HttpPost]
        public async Task<IActionResult> SignInEnter()
        {
            var form = HttpContext.Request.Form;
            
            if (!form.ContainsKey("email") || !form.ContainsKey("password"))
            {
                return RedirectToAction("SignIn");
            }
 
            string email = form["email"]!;
            string password = form["password"]!;

            User? user = people.User(email, password);
            
            if (user is null)
            {
                ViewData["information"] = "Wrong address and/or password";
                return View("SignIn");
            }
            
            people!.SetUser(user);

            string? rememberMe = form["rememberMe"];

            AddRemeberMe(rememberMe, password, email);

            return await AddCookies(user.Email);
        }

        async Task<IActionResult> AddCookies(string email)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, email) };
            
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));

            return RedirectPermanent("/Home/Index");
        }

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            people.SetUser(new User());

            Response.Cookies.Delete("password");
            Response.Cookies.Delete("email");

            await HttpContext.SignOutAsync("Cookies");

            return Redirect("/Home/Index");
        }
    
        void AddRemeberMe(string? rememberMe, string password, string email)
        {
            if(rememberMe is not null)
            {
                Response.Cookies.Append("password", password);
                Response.Cookies.Append("email", email);
            }
        }
    }
}