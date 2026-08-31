using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebStoreAdmin.ViewModels.Employes
{
    // Reconstruit à partir des usages observés dans EmployesController et Edit.cshtml.
    // Si votre fichier réel contient d'autres attributs/annotations, fusionnez plutôt
    // que d'écraser — seuls Photo et PhotoUrlActuelle sont de nouveaux ajouts.
    public class EmployesModifierVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "Courriel")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Poste")]
        public string Poste { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Département")]
        public string Departement { get; set; } = string.Empty;

        [Display(Name = "Date d'embauche")]
        public DateTime DateEmbauche { get; set; }

        [Display(Name = "Nouvelle photo")]
        public IFormFile? Photo { get; set; }

        // Chemin de la photo actuelle (pour l'aperçu) — pas un champ du formulaire à valider.
        public string? PhotoUrlActuelle { get; set; }
    }
}