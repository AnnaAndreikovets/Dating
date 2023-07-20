using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public IActionResult LogIn(string message = "Log in!")
        {
            return View(message);
        }
        
        [HttpGet]
        public IActionResult SignIn(string message = "Log in!")
        {
            return View(message);
        }

        [HttpPost]
        public async Task<IActionResult> LogInEnter() //Login POSSSST
        {
            /*var form = HttpContext.Request.Form;
            
            if (!form.ContainsKey("email") || !form.ContainsKey("password")) return RedirectToAction("LogIn", new { message = "Wrong email and/or password!"});
 
            string email = form["Email"]!;
            string password = form["Password"]!;
     
            Blank? person = people.Blanks().FirstOrDefault(p => p.User.Email == email && p.User.Password == password);
            
            if (person is not null) return RedirectToAction("LogIn", new { message = "User is already exists!"});

            return RedirectToAction("CreateAccount", new { email = email, password = password});*/
            throw new NotImplementedException();
        }

        public async Task<IActionResult> CreateAccount(string email, string password) //Login POSSSST
        {
            /*var form = HttpContext.Request.Form;

            Byte.TryParse(form["Years"], out byte years);
//логика для добавления картинки
//проверка, что все значения заданы корректно
            Blank person = new Blank()
            {
                Id = Guid.NewGuid(),
                FirstName = form["FirstName"],
                SecondName = form["SecondName"],
                Years = years,
                Photo = "", //сюда добавить свой путь
                Description = form["Description"],
                Sex = form["Sex"],
                PreferSex = form["PreferSex"],
                
                User = new User()
                {
                    Email = email,
                    Password = password
                }
            };

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.User.Email) };
            
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));

            return RedirectToRoute("default");*/
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> SignInEnter() //Login POSSSST
        {
            var form = HttpContext.Request.Form;
            
            if (!form.ContainsKey("email") || !form.ContainsKey("password")) return RedirectToAction("LogIn", new { message = "Wrong email and/or password!"});
 
            string email = form["Email"]!;
            string password = form["Password"]!;
     
            User? person = people?.Users()?.FirstOrDefault(p => p.Email == email && p.Password == password);
            
            if (person is null) return RedirectToAction("LogIn", new { message = "User is not found!"});
    
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Email) };
            
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));

            return RedirectToRoute("default");
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync("Cookies");

            return RedirectToAction("Login");
        }
    }
}