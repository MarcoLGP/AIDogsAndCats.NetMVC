using AIDogsAndCats.Models;
using Microsoft.AspNetCore.Mvc;
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
            List<string> ImageExtensions = new() { ".JPG", ".JPEG", ".JPE", ".BMP", ".GIF", ".PNG" };
            string extension = Path.GetExtension(form.Image.FileName);            
            if (!ImageExtensions.Contains(extension.ToUpper()))
            {
                ViewBag.Error = "* Arquivo inválido, utilize uma imagem";
                return View();
            }

            string wwwrootPath = _webHostEnvironment.WebRootPath;
            if (!Directory.Exists(wwwrootPath + "/imageUploaded"))
            {
                Directory.CreateDirectory(wwwrootPath + "/imageUploaded");
            }

            string fileName = Path.GetFileNameWithoutExtension(form.Image.FileName);
            form.ImageName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string pathImage = Path.Combine(wwwrootPath + "/imageUploaded/", form.ImageName);
            
            using (FileStream fileStream = new(pathImage, FileMode.Create))
            {
                await form.Image.CopyToAsync(fileStream);
            }

            AIDogsAndCatsMlModel aIDogsAndCatsMlModel = new();
            using (Image image = Image.FromFile(pathImage))
            {
                using (MemoryStream m = new())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    aIDogsAndCatsMlModel.GetPredict(imageBytes);

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    aIDogsAndCatsMlModel.ImageModel = $"data:image/{extension};base64,{base64String}";
                }
            }

            System.IO.File.Delete(pathImage);
            return View(viewName: "Resultado", model: aIDogsAndCatsMlModel);
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