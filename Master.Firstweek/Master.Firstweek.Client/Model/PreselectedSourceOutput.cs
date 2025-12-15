using System.Text.Json.Serialization;

namespace Master.Firstweek.Client.Model;

public class PreselectedSourceOutput
{
    /// <summary>
    ///     A masked version of the account number that was used for making the payment.
    /// </summary>
    /// <value>A masked version of the account number that was used for making the payment.</value>
    [JsonPropertyName("maskedAccountNumber")]
    public string? MaskedAccountNumber { get; set; }

    /// <summary>
    ///     Id of the Remember Payer Token.
    /// </summary>
    /// <value>Id of the Remember Payer Token.</value>
    [JsonPropertyName("payerTokenId")]
    public Guid? PayerTokenId { get; set; }

    /// <summary>
    ///     Flag for dealing with not straightforward mapping of provider from preselected source.
    /// </summary>
    /// <value>Flag for dealing with not straightforward mapping of provider from preselected source.</value>
    [JsonPropertyName("allowAccountChange")]
    public bool? AllowAccountChange { get; set; }
}