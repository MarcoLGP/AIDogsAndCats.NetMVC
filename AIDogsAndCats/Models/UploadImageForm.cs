using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AIDogsAndCats.Models
{
    public class UploadImageForm
    {
        [Required(ErrorMessage = "Selecione uma imagem para continuar", AllowEmptyStrings = false)]
        [MaxFileSize(maxFileSize: 1073741824)]
        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }
        public string? ImageInBase64 { get; set; }
    }
}
