namespace WebStoreAdmin.ViewModels.Clients
{
    public class ClientsSupprimerVM
    {
        public int Id { get; set; }

        public string NomComplet { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int NombreCommandes { get; set; }
    }
}
