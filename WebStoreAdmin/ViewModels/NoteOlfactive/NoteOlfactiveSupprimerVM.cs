namespace WebStoreAdmin.ViewModels.NoteOlfactive
{
    public class NoteOlfactiveSupprimerVM
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public string? FamilleOlfactiveNom { get; set; }
        public int NombreParfums { get; set; }
    }
}