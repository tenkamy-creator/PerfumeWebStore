using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebStoreAdmin.ViewModels.Employes
{
    public class EmployesAjouterVM
    {
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
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string MotDePasse { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Poste")]
        public string Poste { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Département")]
        public string Departement { get; set; } = string.Empty;

        [Display(Name = "Date d'embauche")]
        public DateTime DateEmbauche { get; set; }
            = DateTime.Today;

        [Required]
        [Display(Name = "Rôle")]
        public string Role { get; set; } = string.Empty;
        public List<SelectListItem> Roles { get; set; } = new();

        [Display(Name = "Photo")]
        public IFormFile? Photo { get; set; }
    }
}