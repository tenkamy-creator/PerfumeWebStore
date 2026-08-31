using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using WebStoreAdmin.Models;
using WebStoreAdmin.Services;
using WebStoreAdmin.ViewModels;

public class RegisterModel(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager,
    ILogger<RegisterModel> logger,
    IUserStore<ApplicationUser> userStore,
    RegisterService registerService) : PageModel
{
    [BindProperty]
    public RegisterInputVM Input { get; set; } = new();

    public RegisterViewModel VM { get; set; } = new();  // ← listes déroulantes

    public string? ReturnUrl { get; set; }

    public IList<AuthenticationScheme> ExternalLogins { get; set; } = [];

    public async Task<IActionResult> OnGetAsync(string? returnUrl = null)
    {
        ReturnUrl = returnUrl;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");

        //registerService.ValidateTypeFields(Input, ModelState);

        if (!ModelState.IsValid)
            return Page();

        var user = new ApplicationUser
        {
            Email = Input.Email,
            UserName = Input.Email,
            Nom = Input.Nom,
            Surnom = Input.Surnom,
            Adresse = Input.Adresse
        };

        await userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
        var result = await userManager.CreateAsync(user, Input.Password);

        if (result.Succeeded)
        {
            //await registerService.CreateSpecializedUserAsync(user, Input);
            //await registerService.AssignRoleAsync(user, Input);
            await signInManager.SignInAsync(user, isPersistent: false);
            return LocalRedirect(returnUrl);
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError(string.Empty, error.Description);

        return Page();
    }
}