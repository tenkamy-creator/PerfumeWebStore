using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebStoreAdmin.ViewModels.NoteOlfactive
{
    public class NoteOlfactiveAjouterVM
    {
        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; } = string.Empty;

        [Display(Name = "Famille olfactive")]
        public int? FamilleOlfactiveId { get; set; }
        public List<SelectListItem> Familles { get; set; } = new();

        [Display(Name = "Image")]
        public IFormFile? Image { get; set; }
    }
}