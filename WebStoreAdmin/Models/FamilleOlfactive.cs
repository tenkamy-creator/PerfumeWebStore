namespace WebStoreAdmin.Models
{
    public class FamilleOlfactive
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        public List<NoteOlfactive> Notes { get; set; } = new();
    }
}