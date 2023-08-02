using DatingSite.Data;
using DatingSite.Data.Models;
using Microsoft.AspNetCore.Mvc;
using DatingSite.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace DatingSite.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        readonly IPeople people;
        readonly ApplicationDBContext context;

        public ProfileController(IPeople people, ApplicationDBContext context)
        {
            this.people = people;
            this.context = context;
        }

        public IActionResult Index(Guid blankId, Guid userId)
        {
            Anket? anket = people.Anket(userId);

            if(anket is null)
            {
                throw new ArgumentNullException("Invalid user data!");
            }

            if(anket.Like)
            {
                Blank? person = people.Blank(blankId);

                if(person is not null)
                {
                    return View(person);
                }
            }

            return RedirectPermanent("/Home/Index");
        }
        
        new public IActionResult User()
        {
            return View(people.CurrentUser());
        }

        public IActionResult Settings()
        {
            return View(people.CurrentUser());
        }

        [HttpPost]
        public async Task<IActionResult> Change()
        {
            var form = HttpContext.Request.Form;

            User user = people.User();

            Blank? blank = people.Blank(user.BlankId);

            if(blank is null)
            {
                throw new NullReferenceException("Invalid user data!");
            }

            if (!form.ContainsKey("firstName") || !form.ContainsKey("secondName")  || !form.ContainsKey("age") || !form.ContainsKey("description") || !form.ContainsKey("sex") || !form.ContainsKey("preferSex"))
            {
                return RedirectToAction("LogIn");
            }

            string firstName = form["firstName"]!;
            string secondName = form["secondName"]!;
            string description = form["description"]!;
            string sex = form["sex"]!;
            string preferSex = form["preferSex"]!;
            Byte.TryParse(form["age"], out byte age);

            if(form.Files.GetFile("photo") is not null)
            {
                var photo = form.Files.GetFile("photo")!;
                var newFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);
                string imagePath = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img"), newFileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    photo.CopyTo(stream);
                }

                blank.Photo = $"/img/{newFileName}";
            }
            
            if(blank.FirstName != firstName)
            {
                blank.FirstName = firstName;
            }

            if(blank.SecondName != secondName)
            {
                blank.SecondName = secondName;
            }

            if(blank.Age != age)
            {
                blank.Age = age;
            }

            if(blank.Description != description)
            {
                blank.Description = description;
            }

            if(blank.Sex != sex)
            {
                blank.Sex = sex;
            }

            if(blank.PreferSex != preferSex)
            {
                blank.PreferSex = preferSex;
            }

            await context.SaveChangesAsync();

            return RedirectToAction("User");
        }

        public IActionResult Password()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword()
        {
            var form = HttpContext.Request.Form;

            User user = people.User(people.User().Id)!;

            if (!form.ContainsKey("password"))
            {
                return RedirectToAction("LogIn");
            }
            
            user.Password = form["password"]!;

            await context.SaveChangesAsync();

            return RedirectToAction("User");
        }
    }
}