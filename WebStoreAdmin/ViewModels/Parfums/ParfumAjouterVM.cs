using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WebStoreAdmin.Models;

namespace WebStoreAdmin.ViewModels.Parfums
{
    public class ParfumAjouterVM
    {
        [Required]
        public string Nom { get; set; }

        [Required]
        public string Marque { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Prix { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public Genres Genre { get; set; }

        [ValidateNever]
        public List<SelectListItem> Genres { get; set; } = new();

        [Required]
        public int CategorieId { get; set; }

        [Required]
        [Display(Name = "Volume (ml)")]
        [Range(1, 1000)]
        public double Volume { get; set; }

        [ValidateNever]
        public List<IFormFile> Images { get; set; } = new();

        [Display(Name = "Image principale")]
        public int ImagePrincipaleIndex { get; set; }

        [ValidateNever]
        public List<SelectListItem> Categories { get; set; } = new();

        [ValidateNever]
        public Categorie Categorie { get; set; } = default!;

        public List<int> NotesTeteIds { get; set; } = new();
        public List<int> NotesCoeurIds { get; set; } = new();
        public List<int> NotesFondIds { get; set; } = new();

        [ValidateNever]
        public List<SelectListItem> NotesDisponibles { get; set; } = new();
    }
}