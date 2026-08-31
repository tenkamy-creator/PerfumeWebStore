using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WebStoreAdmin.Models;

namespace WebStoreAdmin.ViewModels.Parfums
{
    public class ParfumModifierVM
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; } = string.Empty;

        [Required]
        public string Marque { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public double Prix { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public Genres Genre { get; set; }

        [ValidateNever]
        public List<SelectListItem> Genres { get; set; } = new();

        [Required]
        [Display(Name = "Volume (ml)")]
        [Range(1, 1000)]
        public double Volume { get; set; }

        [Required]
        public int CategorieId { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? Categories { get; set; }

        // nouvelles images (optionnelles lors de la modification)
        [ValidateNever]
        public List<IFormFile>? Images { get; set; } = new();

        // image principale
        public int? ImagePrincipaleId { get; set; }

        // images déjà enregistrées
        [ValidateNever]
        public List<ImageParfum> ImagesExistantes { get; set; } = new();

        public int? NouvelleImagePrincipaleIndex { get; set; }

        public List<int> NotesTeteIds { get; set; } = new();
        public List<int> NotesCoeurIds { get; set; } = new();
        public List<int> NotesFondIds { get; set; } = new();

        [ValidateNever]
        public List<SelectListItem> NotesDisponibles { get; set; } = new();
    }
}