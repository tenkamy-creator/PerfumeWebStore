namespace WebStoreAdmin.ViewModels.Employes
{
    // Reconstruit à partir des usages observés dans EmployesController.Details.
    public class EmployesDetailsVM
    {
        public int Id { get; set; }
        public string Prenom { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Poste { get; set; } = string.Empty;
        public string Departement { get; set; } = string.Empty;
        public DateTime DateEmbauche { get; set; }
        public string? PhotoUrl { get; set; }
    }
}