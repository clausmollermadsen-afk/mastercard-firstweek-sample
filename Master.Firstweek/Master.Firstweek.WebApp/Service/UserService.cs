using Master.Firstweek.WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Master.Firstweek.WebApp.Service;

/// <summary>
///     Service for managing application users.
/// </summary>
public class UserService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<UserService> _logger;

    /// <summary>
    ///     Initializes a new instance of the <see cref="UserService" /> class.
    /// </summary>
    /// <param name="context">The application database context.</param>
    /// <param name="logger">The logger instance.</param>
    public UserService(ApplicationDbContext context, ILogger<UserService> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    ///     Adds 100 test users to the database.
    /// </summary>
    public async Task AddTestUsersAsync()
    {
        for (int i = 0; i < 100; i++)
        {
            _context.Users.Add(
                new ApplicationUser
                {
                    Address = $"Address{i}",
                    Email = $"Email{i}",
                    Token = Guid.NewGuid().ToString(),
                    UserName = $"UserName{i}",
                    Active = true,
                    Bills = new List<Bill>()
                }
            );
        }

        await _context.SaveChangesAsync();
        _logger.LogInformation("Added 100 test users to the database.");
    }

    /// <summary>
    ///     Gets all users from the database.
    /// </summary>
    /// <returns>A list of all application users.</returns>
    public async Task<List<ApplicationUser>> GetUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    /// <summary>
    ///     Updates the specified user in the database.
    /// </summary>
    /// <param name="user">The user to update.</param>
    public async Task UpdateUserAsync(ApplicationUser user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        _logger.LogInformation("Updated user with ID: {UserId}", user.Id);
    }
}