using System.Text.Json.Serialization;

namespace Master.Firstweek.Client.Model;

public class PaymentProviderStatusOutput
{
    /// <summary>
    ///     Gets or Sets Code
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; }
}