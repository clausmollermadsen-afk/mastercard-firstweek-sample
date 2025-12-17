using Master.Firstweek.WebApp.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Master.Firstweek.WebApp.Pages;

public class Logout : PageModel
{
    private readonly CustomAuthStateProvider _authProvider;

    public Logout(AuthenticationStateProvider authStateProvider)
    {
        _authProvider = (CustomAuthStateProvider)authStateProvider;
    }

    public async Task<IActionResult> OnGet()
    {
        await _authProvider.SignOutAsync();
        return LocalRedirect("/Initialize");
    }
}