using System.Text.Json;
using Master.Firstweek.Client.Model;

namespace Master.Firstweek.Client.Test;

/// <summary>
/// Logger for requests and responses in tests. Serializes objects to formatted JSON for easy reading in test output.
/// </summary>
public class TestRequestResponseLogger : IRequestResponseLogger
{
    /// <summary>
    ///     JSON serializer options for indented output.
    /// </summary>
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true
    };

    /// <summary>
    /// Logs a request and response to the console as formatted JSON.
    /// </summary>
    /// <typeparam name="TRequest">The request type.</typeparam>
    /// <typeparam name="TResponse">The response type.</typeparam>
    /// <param name="request">The request object.</param>
    /// <param name="response">The response object.</param>
    /// <param name="errorResponse">The error response, if any.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public Task LogRequestResponseAsync<TRequest, TResponse>(TRequest request, TResponse response,
        CancellationToken cancellationToken = default) where TRequest : class where TResponse : class
    {
        Console.WriteLine($"Request: {JsonSerializer.Serialize(request, JsonOptions)}");
        Console.WriteLine($"Response: {JsonSerializer.Serialize(response, JsonOptions)}");
        return Task.CompletedTask;
    }

    /// <summary>
    /// Logs a request and error response to the console as formatted JSON.
    /// </summary>
    /// <typeparam name="TRequest">The request type.</typeparam>
    /// <param name="request">The request object.</param>
    /// <param name="errorResponse">The error response.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public Task LogRequestErrorAsync<TRequest>(TRequest request, ErrorResponse errorResponse,
        CancellationToken cancellationToken = default) where TRequest : class
    {
        Console.WriteLine($"Request: {JsonSerializer.Serialize(request, JsonOptions)}");
        Console.WriteLine($"Error: {JsonSerializer.Serialize(errorResponse, JsonOptions)}");
        return Task.CompletedTask;
    }
}