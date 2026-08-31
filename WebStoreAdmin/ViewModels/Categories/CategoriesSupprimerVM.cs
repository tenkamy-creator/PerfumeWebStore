using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebStoreAdmin.ViewModels.Categories
{
    public class CategoriesSupprimerVM
    {
        public int Id { get; set; }
        public string Nom { get; set; } = default!;
        public string Description { get; set; } = default!;
        public List<int>? ParfumsIds { get; set; }
        public List<SelectListItem>? Parfums { get; set; }
    }
}
