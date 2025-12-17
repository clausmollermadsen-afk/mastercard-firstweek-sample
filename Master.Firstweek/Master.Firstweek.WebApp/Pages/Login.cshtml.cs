using Master.Firstweek.WebApp.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Master.Firstweek.WebApp.Pages;

public class Login : PageModel
{
    private readonly CustomAuthStateProvider _authProvider;

    public Login(AuthenticationStateProvider authStateProvider)
    {
        _authProvider = (CustomAuthStateProvider)authStateProvider;
    }

    [BindProperty(SupportsGet = true)] public Guid Token { get; set; }

    public async Task<IActionResult> OnGet(string returnUrl = "/")
    {
        if (await _authProvider.SignIn(Token.ToString()))
        {
            // Tell Blazor to refresh its AuthenticationState
            _authProvider.NotifyUserChanged();
            return LocalRedirect("/PostLogin");
        }

        return LocalRedirect("/NoAccess");
    }
}