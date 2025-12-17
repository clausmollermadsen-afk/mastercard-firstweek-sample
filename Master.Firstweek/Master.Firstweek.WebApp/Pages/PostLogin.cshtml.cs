using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Master.Firstweek.WebApp.Pages;

public class PostLogin : PageModel
{
    public async Task<IActionResult> OnGet()
    {
        return LocalRedirect("/Bill");
    }
}