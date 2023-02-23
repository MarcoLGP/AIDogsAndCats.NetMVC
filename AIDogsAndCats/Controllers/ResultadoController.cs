using AIDogsAndCats.Models;
using Microsoft.AspNetCore.Mvc;

namespace AIDogsAndCats.Controllers
{
    public class ResultadoController : Controller
    {
        public IActionResult Index(UploadImageForm form)
        {
            if (form.ImageName == null)
            {
                return Redirect("/");
            }
            Console.WriteLine(form.ImageName);
            return View();
        }
    }
}
