using Microsoft.AspNetCore.Mvc;
using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using DatingSite.Data.Mocks;

namespace DatingSite.Controllers
{
    public class ProfileController : Controller
    {
        readonly IBlank blank;

        public ProfileController(IBlank blank)
        {
            this.blank = blank;
        }

        [Route("Profile/Index/{guid}")]
        public IActionResult Index(Guid guid)
        {
            //для отображения профиля через сообщение
            //проверка, что он нам нравится иначе вернуть дефолтную страницу
            Blank person = blank.Person(guid);

            return View(person);
        }
        [Route("Profile/User")]
        public IActionResult User()
        {
            //для отображения нашего профиля
            return View(MockBlanks.User);
        }

    }
}