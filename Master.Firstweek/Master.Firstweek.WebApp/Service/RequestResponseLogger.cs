using System.Text.Json;
using Master.Firstweek.Client;
using Master.Firstweek.Client.Model;
using Master.Firstweek.WebApp.Data;

namespace Master.Firstweek.WebApp.Service;

/// <summary>
///     Logs requests and responses to the database for auditing and troubleshooting.
/// </summary>
public class RequestResponseLogger : IRequestResponseLogger
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<RequestResponseLogger> _logger;

    /// <summary>
    ///     Initializes a new instance of the <see cref="RequestResponseLogger" /> class.
    /// </summary>
    /// <param name="context">The application database context.</param>
    /// <param name="logger">The logger instance.</param>
    public RequestResponseLogger(ApplicationDbContext context, ILogger<RequestResponseLogger> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    ///     Logs a request and response, including any error response, to the database.
    /// </summary>
    /// <typeparam name="TRequest">The request type.</typeparam>
    /// <typeparam name="TResponse">The response type.</typeparam>
    /// <param name="request">The request object.</param>
    /// <param name="response">The response object.</param>
    /// <param name="errorResponse">The error response, if any.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task LogRequestResponseAsync<TRequest, TResponse>(TRequest request, TResponse response,
        CancellationToken cancellationToken = default) where TRequest : class where TResponse : class
    {
        var log = new RequestResponseLog
        {
            Request = JsonSerializer.Serialize(request),
            Response = JsonSerializer.Serialize(response)
        };
        await _context.RequestResponseLogs.AddAsync(log, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    ///     Logs a request and error response to the database.
    /// </summary>
    /// <typeparam name="TRequest">The request type.</typeparam>
    /// <param name="request">The request object.</param>
    /// <param name="errorResponse">The error response.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task LogRequestErrorAsync<TRequest>(TRequest request, ErrorResponse errorResponse,
        CancellationToken cancellationToken = default) where TRequest : class
    {
        var log = new RequestResponseLog
        {
            Request = JsonSerializer.Serialize(request),
            Error = JsonSerializer.Serialize(errorResponse)
        };
        await _context.RequestResponseLogs.AddAsync(log, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}