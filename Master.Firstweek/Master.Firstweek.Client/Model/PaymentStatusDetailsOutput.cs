using System.Text.Json.Serialization;

namespace Master.Firstweek.Client.Model;

public class PaymentStatusDetailsOutput
{
    /// <summary>
    ///     Gets or Sets Code
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>
    ///     Gets or Sets Reason
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// Gets or Sets Provider
    /// </summary>
    [JsonPropertyName("provider")]
    public PaymentProviderStatusOutput? Provider { get; set; }
}