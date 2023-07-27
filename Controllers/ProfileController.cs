using Microsoft.AspNetCore.Mvc;
using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace DatingSite.Controllers
{
    //[Authorize]
    public class ProfileController : Controller
    {
        readonly IPeople people;

        public ProfileController(IPeople people)
        {
            this.people = people;
        }

        [Route("Profile/Index")]
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
        
        [Route("Profile/User")]
        new public IActionResult User()
        {
            return View(people.CurrentUser());
        }

        [Route("Profile/Settings")]
        public IActionResult Settings()
        {
            return View(people.CurrentUser());
        }

        [HttpPost]
        [Route("Profile/Change")]
        public IActionResult Change()
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

            return RedirectToAction("User");
        }

        [Route("Profile/Password")]
        public IActionResult Password()
        {
            return View();
        }

        [HttpPost]
        [Route("Profile/ChangePassword")]
        public IActionResult ChangePassword()
        {
            var form = HttpContext.Request.Form;

            User user = people.User();

            if (!form.ContainsKey("password"))
            {
                return RedirectToAction("LogIn");
            }

            user.Password = form["password"]!;

            return RedirectToAction("User");
        }
    }
}