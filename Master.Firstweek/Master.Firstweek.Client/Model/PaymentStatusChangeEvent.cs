using System.Text.Json.Serialization;

namespace Master.Firstweek.Client.Model;

public class PaymentStatusChangeEvent
{
    /// <summary>
    ///     The state change event
    /// </summary>
    /// <value>The state change event</value>
    /* <example>Requested</example> */
    [JsonPropertyName("event")]
    public string? Event { get; set; }

    /// <summary>
    ///     The timestamp the event occurred at
    /// </summary>
    /// <value>The timestamp the event occurred at</value>
    /* <example>2024-01-17T12:29:36.919957Z</example> */
    [JsonPropertyName("timestamp")]
    public DateTime? Timestamp { get; set; }
}