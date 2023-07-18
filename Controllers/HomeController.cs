using Microsoft.AspNetCore.Mvc;

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