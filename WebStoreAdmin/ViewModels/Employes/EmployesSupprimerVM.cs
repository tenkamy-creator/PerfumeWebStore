using System.ComponentModel.DataAnnotations;

namespace WebStoreAdmin.ViewModels.Employes
{
    public class EmployesSupprimerVM
    {
        public int Id { get; set; }

        public string NomComplet { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Poste { get; set; } = string.Empty;

        [Display(Name = "Photo")]
        public string? PhotoUrl { get; set; }

        public string Departement { get; set; } = string.Empty;
    }
}
