using Master.Firstweek.WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Master.Firstweek.WebApp.Service;

/// <summary>
///     Service for managing bills for the current user.
/// </summary>
public class BillService
{
    private readonly ApplicationDbContext _context;
    private readonly CurrentUser _currentUser;

    /// <summary>
    ///     Initializes a new instance of the <see cref="BillService" /> class.
    /// </summary>
    /// <param name="context">The application database context.</param>
    /// <param name="currentUser">The current user service.</param>
    public BillService(ApplicationDbContext context, CurrentUser currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }

    /// <summary>
    ///     Adds a bill for each active user.
    /// </summary>
    public async Task AddBills()
    {
        foreach (var user in await _context.Users.Where(x => x.Active).ToListAsync())
        {
            _context.Bills.Add(new Bill
            {
                ApplicationUser = user,
                Amount = 150,
                FromDate = DateTime.Now.Date,
                ToDate = DateTime.Now.AddDays(1),
                Status = "Created",
                FK_UserId = user.Id
            });
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    ///     Gets all bills for the current user.
    /// </summary>
    /// <returns>A list of bills for the current user, or an empty list if not found.</returns>
    public async Task<IEnumerable<Bill>> GetBills()
    {
        var user = await _currentUser.GetUser();
        if (user == null)
            return Enumerable.Empty<Bill>();

        return await _context.Bills
            .Include(x => x.Payments)
            .Where(x => x.ApplicationUser == user)
            .ToListAsync();
    }

    /// <summary>
    ///     Gets a specific bill for the current user by bill ID.
    /// </summary>
    /// <param name="billId">The bill ID.</param>
    /// <returns>The bill if found, otherwise null.</returns>
    public async Task<Bill?> GetBill(long billId)
    {
        var user = await _currentUser.GetUser();
        if (user == null)
            return null;

        return await _context.Bills
            .FirstOrDefaultAsync(x => x.ApplicationUser == user && x.Id == billId);
    }
}