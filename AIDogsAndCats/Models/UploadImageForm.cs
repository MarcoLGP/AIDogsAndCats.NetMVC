using System.ComponentModel.DataAnnotations;

namespace AIDogsAndCats.Models
{
    public class UploadImageForm
    {
        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }
        public string? ImageInBase64 { get; set; }
    }
}
