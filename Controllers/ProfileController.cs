using Microsoft.AspNetCore.Mvc;
using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;

namespace DatingSite.Controllers
{
    public class ProfileController : Controller
    {
        readonly IPeople people;

        public ProfileController(IPeople people)
        {
            this.people = people;
        }

        [Route("Profile/Index/{guid}")]
        public IActionResult Index(Guid guid)
        {
            //проверка, что он нам нравится иначе вернуть дефолтную страницу
            Blank? person = people.Blank(guid);

            return View(person);
        }
        
        [Route("Profile/User")]
        new public IActionResult User()
        {
            return View(people.CurrentUser());
        }

        public IActionResult Settings()
        {
            return View(people.CurrentUser());
        }

    }
}