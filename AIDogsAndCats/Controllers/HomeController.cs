using AIDogsAndCats.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AIDogsAndCats.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UploadImageForm form)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(form.Image);
                ViewBag.Message = "Nice";
                return View();
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Sobre()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}