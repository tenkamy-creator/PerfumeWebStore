using Microsoft.AspNetCore.Identity;
using WebStoreAdmin.Models;

namespace WebStoreAdmin.Data
{
    public class SeedData
    {
        public static async Task SeedRolesAsync(IServiceProvider services)
        {
            var roleManager =
                services.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles =
            {
        Roles.Administrateur,
        Roles.Gestionnaire,
        Roles.Vendeur
    };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(
                        new IdentityRole(role));
                }
            }
        }
    }
}
