using Microsoft.AspNetCore.Mvc;
using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;

namespace DatingSite.Controllers
{
    public class AnketsController : Controller
    {
        IBlank blank { get; set; }

        public AnketsController(IBlank blank)
        {
            this.blank = blank;
        }

        [Route("Ankets/List/{male}")]
        public IActionResult Index(string male)
        {
            //vm
            var result = blank.PersonForLooking(male);
            return View(result);
        }

        [Route("Ankets/Skip/{blank}")]
        [Route("Ankets/Skip/{blank}/{like}")]
        public IActionResult Skip(Guid guid, bool like)
        {
            Blank? _blank = blank.Person(guid);

            if(like)
            {
                _blank.Like = true;
            }

            _blank.See = true;

            return RedirectToAction("Index", new {_blank.Sex});
        }
    }
}