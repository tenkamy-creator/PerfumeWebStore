using System.ComponentModel.DataAnnotations;

namespace WebStoreAdmin.ViewModels.FamilleOlfactive
{
    public class FamilleOlfactiveAjouterVM
    {
        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; } = string.Empty;

        [Display(Name = "Image")]
        public IFormFile? Image { get; set; }
    }
}