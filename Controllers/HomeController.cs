using Microsoft.AspNetCore.Mvc;
using DatingSite.Data;

namespace DatingSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}