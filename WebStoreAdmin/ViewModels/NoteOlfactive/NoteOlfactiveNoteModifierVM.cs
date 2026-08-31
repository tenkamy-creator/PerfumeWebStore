using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebStoreAdmin.ViewModels.NoteOlfactive
{
    public class NoteOlfactiveModifierVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; } = string.Empty;

        [Display(Name = "Famille olfactive")]
        public int? FamilleOlfactiveId { get; set; }
        public List<SelectListItem> Familles { get; set; } = new();

        [Display(Name = "Nouvelle image")]
        public IFormFile? Image { get; set; }

        public string? ImageUrlActuelle { get; set; }
    }
}