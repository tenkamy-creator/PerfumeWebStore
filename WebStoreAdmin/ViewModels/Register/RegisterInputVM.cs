using System.ComponentModel.DataAnnotations;

namespace WebStoreAdmin.ViewModels
{
    public class RegisterInputVM
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 6,
            ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe")]
        [Compare("Password",
            ErrorMessage = "Le mot de passe et la confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Veuillez sélectionner un type d'utilisateur.")]
        //[Display(Name = "Type d'utilisateur")]
        //public string TypeUtilisateur { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Surnom")]
        public string Surnom { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; } = string.Empty;

        [Display(Name = "Adresse")]
        public string? Adresse { get; set; }

        // --- Employe ---
        [Display(Name = "Poste")]
        public string? Poste { get; set; }

        [Display(Name = "Departement")]
        public string? Departement { get; set; }

        [Display(Name = "Date d'embauche")]
        public DateTime? DateEmbaucheEmploye { get; set; }
    }
}
