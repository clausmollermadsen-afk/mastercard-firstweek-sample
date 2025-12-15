using Master.Firstweek.Client.Model;

namespace Master.Firstweek.Client;

/// <summary>
///     Interface for logging requests and responses for auditing and troubleshooting.
/// </summary>
public interface IRequestResponseLogger
{
    /// <summary>
    ///     Logs a request and response, including any error response, for auditing purposes.
    /// </summary>
    /// <typeparam name="TRequest">The request type.</typeparam>
    /// <typeparam name="TResponse">The response type.</typeparam>
    /// <param name="request">The request object.</param>
    /// <param name="response">The response object.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task LogRequestResponseAsync<TRequest, TResponse>(TRequest request, TResponse response,
        CancellationToken cancellationToken = default) where TRequest : class where TResponse : class;

    /// <summary>
    ///     Logs a request and error response for auditing purposes.
    /// </summary>
    /// <typeparam name="TRequest">The request type.</typeparam>
    /// <param name="request">The request object.</param>
    /// <param name="errorResponse">The error response.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task LogRequestErrorAsync<TRequest>(TRequest request, ErrorResponse errorResponse,
        CancellationToken cancellationToken = default) where TRequest : class;
}