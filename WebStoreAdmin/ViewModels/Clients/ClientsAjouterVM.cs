using System.ComponentModel.DataAnnotations;

namespace WebStoreAdmin.ViewModels.Clients
{
    public class ClientsAjouterVM
    {
        [Required]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; } = string.Empty;

        [Required]
        [Compare(nameof(MotDePasse))]
        [Display(Name = "Confirmation")]
        public string ConfirmationMotDePasse { get; set; } = string.Empty;
    }
}
