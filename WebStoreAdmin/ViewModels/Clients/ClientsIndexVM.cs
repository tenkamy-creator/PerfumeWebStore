namespace WebStoreAdmin.ViewModels.Clients
{
    public class ClientsIndexVM
    {
        public int Id { get; set; }

        public string NomComplet { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int NombreCommandes { get; set; }
    }
}
