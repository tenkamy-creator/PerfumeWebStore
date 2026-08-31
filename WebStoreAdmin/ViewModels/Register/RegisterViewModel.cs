using System.ComponentModel.DataAnnotations;
using WebStoreAdmin.Models;

namespace WebStoreAdmin.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Surnom { get; set; }
        [Required]
        public string Nom { get; set; }
        public string? Adresse { get; set; }
        //[Required]
        //public Peuple? Peuple { get; set; }

        //public GuerrierGondorViewModel Gondor { get; set; }
        //public ElfeViewModel Elfe { get; set; }
        //public HobbitComteViewModel Hobbit { get; set; }
    }

}
