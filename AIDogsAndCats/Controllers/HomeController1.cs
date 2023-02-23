using Microsoft.AspNetCore.Mvc;

namespace AIDogsAndCats.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
