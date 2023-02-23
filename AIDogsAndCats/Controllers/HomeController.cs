using AIDogsAndCats.Models;
using Microsoft.AspNetCore.Mvc;
using System.Buffers.Text;
using System.Diagnostics;
using System.Drawing;

namespace AIDogsAndCats.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(UploadImageForm form)
        {
            string wwwrootPath = _webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(form.Image.FileName);
            string extension = Path.GetExtension(form.Image.FileName);
            form.ImageName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string pathImage = Path.Combine(wwwrootPath + "/imageUploaded", form.ImageName);
            
            using (FileStream fileStream = new(pathImage, FileMode.Create))
            {
                await form.Image.CopyToAsync(fileStream);
            }
            
            using (Image image = Image.FromFile(pathImage))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    form.ImageInBase64 = $"data:image/{extension};base64,{base64String}";
                }
            }

            System.IO.File.Delete(pathImage);
            return View(viewName: "Resultado", model: form);
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