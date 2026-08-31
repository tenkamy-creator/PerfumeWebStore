using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace WebStoreAdmin.Services
{
    public class RegisterService() { }
    //    UserManager<ApplicationUser> userManager,
    //    RoleManager<IdentityRole> roleManager)
    //{
    //    private readonly UserManager<ApplicationUser> _userManager = userManager;
    //    private readonly RoleManager<IdentityRole> _roleManager = roleManager;

    //    public async Task CreateSpecializedUserAsync(
    //        ApplicationUser user, RegisterInputVM input)
    //    {
    //        //switch (input.TypeUtilisateur)
    //        //{
    //        //    case "Elfe":
    //        //        await _elfeService.CreateAsync(new Elfe
    //        //        {
    //        //            UserId = user.Id,
    //        //            RoyaumeElfe = input.Royaume!,
    //        //            AgeElfe = input.Age ?? 0
    //        //        });
    //        //        break;

    //        //    case "Guerrier":
    //        //        await _guerrierService.CreateAsync(new GuerrierGondor
    //        //        {
    //        //            UserId = user.Id,
    //        //            DivisionGondor = input.Division!,
    //        //            RangMilitaire = input.Rang!
    //        //        });
    //        //        break;

    //        //    case "Hobbit":
    //        //        await _hobbitService.CreateAsync(new HobbitComte
    //        //        {
    //        //            UserId = user.Id,
    //        //            MetierHobbit = input.Metier!,
    //        //            Village = input.Village!
    //        //        });
    //        //        break;
    //        //}

    //        // Claim peuple — une seule fois ici
    //        //await _userManager.AddClaimAsync(user,
    //        //    new Claim("Peuple", input.TypeUtilisateur));
    //    }

    //    public async Task AssignRoleAsync(
    //        ApplicationUser user, RegisterInputVM input)
    //    {
    //        //var role = (input.TypeUtilisateur, input.Rang) switch
    //        //{
    //        //    ("Guerrier", "Intendant") => Roles.Roi,
    //        //    ("Guerrier", "Capitaine") => Roles.Capitaine,
    //        //    _ => Roles.Habitant
    //        //};

    //        //if (!await _roleManager.RoleExistsAsync(role))
    //        //    await _roleManager.CreateAsync(new IdentityRole(role));

    //        //await _userManager.AddToRoleAsync(user, role);
    //    }

    //    public void ValidateTypeFields(
    //        RegisterInputVM input,
    //        Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary modelState)
    //    {
    //        //switch (input.TypeUtilisateur)
    //        //{
    //        //    case "Guerrier":
    //        //        if (string.IsNullOrWhiteSpace(input.Rang))
    //        //            modelState.AddModelError("Input.Rang",
    //        //                "Le rang militaire est obligatoire pour un guerrier.");
    //        //        if (string.IsNullOrWhiteSpace(input.Division))
    //        //            modelState.AddModelError("Input.Division",
    //        //                "La division est obligatoire pour un guerrier.");
    //        //        break;
    //        //    case "Elfe":
    //        //        if (string.IsNullOrWhiteSpace(input.Royaume))
    //        //            modelState.AddModelError("Input.Royaume",
    //        //                "Le royaume d'origine est obligatoire pour un elfe.");
    //        //        if (input.Age is null or 0)
    //        //            modelState.AddModelError("Input.Age",
    //        //                "L'âge elfique est obligatoire pour un elfe.");
    //        //        break;
    //        //    case "Hobbit":
    //        //        if (string.IsNullOrWhiteSpace(input.Village))
    //        //            modelState.AddModelError("Input.Village",
    //        //                "Le village d'origine est obligatoire pour un hobbit.");
    //        //        if (string.IsNullOrWhiteSpace(input.Metier))
    //        //            modelState.AddModelError("Input.Metier",
    //        //                "Le métier hobbit est obligatoire pour un hobbit.");
    //        //        break;
    //        //}
    //    }
    //}
}