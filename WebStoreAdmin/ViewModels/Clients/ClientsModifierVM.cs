using System.ComponentModel.DataAnnotations;

namespace WebStoreAdmin.ViewModels.Clients
{
    public class ClientsModifierVM
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
        public string Email { get; set; } = string.Empty;
    }
}
