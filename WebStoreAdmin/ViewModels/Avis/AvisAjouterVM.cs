namespace WebStoreAdmin.ViewModels.Avis
{
    public class AvisAjouterVM
    {
        public int Note { get; set; }
        public string Commentaire { get; set; } = default!;
        public int ClientId { get; set; }
        public int ParfumId { get; set; }
    }
}
