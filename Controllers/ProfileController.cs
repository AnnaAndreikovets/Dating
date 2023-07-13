using Microsoft.AspNetCore.Mvc;
using DatingSite.Data.Interfaces;
using DatingSite.Data;

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
            var person = blank.Person(guid);
            return View(person);
        }
    }
}