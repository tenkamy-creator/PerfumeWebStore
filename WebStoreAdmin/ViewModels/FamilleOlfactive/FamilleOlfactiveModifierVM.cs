using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebStoreAdmin.ViewModels.FamilleOlfactive
{
    public class FamilleOlfactiveModifierVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; } = string.Empty;

        [Display(Name = "Nouvelle image")]
        public IFormFile? Image { get; set; }

        public string? ImageUrlActuelle { get; set; }
    }
}