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
            //для отображения профиля через сообщение
            //проверка, что он нам нравится иначе вернуть дефолтную страницу
            Blank person = people.Person(guid);

            return View(person);
        }
        [Route("Profile/User")]
        public IActionResult User()
        {
            //для отображения нашего профиля
            return View(people.User());
        }

        public IActionResult Settings()
        {
            return View(people.User());
        }

    }
}