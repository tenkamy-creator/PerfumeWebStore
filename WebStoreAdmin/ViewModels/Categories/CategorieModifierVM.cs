using Microsoft.AspNetCore.Mvc.Rendering;
using WebStoreAdmin.Models;

namespace WebStoreAdmin.ViewModels.Categories
{
    public class CategorieModifierVM
    {
        public int Id { get; set; }
        public string Nom { get; set; } = default!;
        public string Description { get; set; } = default!;
        public List<int>? ParfumsIds { get; set; }
        public List<SelectListItem>? Parfums { get; set; }
    }
}
