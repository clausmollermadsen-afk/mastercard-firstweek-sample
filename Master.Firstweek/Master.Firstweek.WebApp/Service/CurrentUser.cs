using System.Security.Claims;
using Master.Firstweek.WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Master.Firstweek.WebApp.Service;

/// <summary>
///     Service for retrieving the current authenticated user from the HTTP context.
/// </summary>
public class CurrentUser
{
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CurrentUser" /> class.
    /// </summary>
    /// <param name="context">The application database context.</param>
    /// <param name="httpContextAccessor">The HTTP context accessor.</param>
    public CurrentUser(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    ///     Gets the current authenticated <see cref="ApplicationUser" /> from the HTTP context.
    /// </summary>
    /// <returns>The current user, or null if not authenticated or not found.</returns>
    public async Task<ApplicationUser?> GetUser()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext == null)
            return null;

        var user = httpContext.User;
        var id = user.FindFirst(ClaimTypes.Sid)?.Value;
        if (string.IsNullOrEmpty(id))
            return null;

        return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }
}