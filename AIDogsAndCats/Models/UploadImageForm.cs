using System.ComponentModel.DataAnnotations;

namespace AIDogsAndCats.Models
{
    public class UploadImageForm
    {
        [Required(ErrorMessage = "Selecione uma imagem para continuar")]
        public string Image { get; set; }
    }
}
