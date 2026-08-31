namespace WebStoreAdmin.Models
{
    public class AdresseLivraison
    {
        public int Id { get; set; }
        public string Rue { get; set; } = string.Empty;
        public string Ville { get; set; } = string.Empty;
        public string Pays { get; set; } = string.Empty;
        public string CodePostal { get; set; } = string.Empty;
        public int ClientId { get; set; }
        public Client Client { get; set; } = new();
    }
}
