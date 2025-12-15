using System.Text.Json.Serialization;

namespace Master.Firstweek.Client.Model;

#pragma warning disable CS8618
public class AcceptPaymentOutput
{
    /// <summary>
    ///     The ID of the payment.
    /// </summary>
    /// <value>The ID of the payment.</value>
    /* <example>472e651e-5a1e-424d-8098-23858bf03ad7</example> */
    [JsonPropertyName("paymentId")]
    public Guid PaymentId { get; set; }

    /// <summary>
    ///     The Destination ID that will receive the payment.
    /// </summary>
    /// <value>The Destination ID that will receive the payment.</value>
    /* <example>472e651e-5a1e-424d-8098-23858bf03ad7</example> */
    [JsonPropertyName("destinationId")]
    public Guid DestinationId { get; set; }

    /// <summary>
    ///     The payment rail by which the payment will be executed.
    /// </summary>
    /// <value>The payment rail by which the payment will be executed.</value>
    /* <example>UkFasterPayments</example> */
    [JsonPropertyName("paymentRail")]
    public string PaymentRail { get; set; }

    /// <summary>
    ///     The payment amount in the specified currency.
    /// </summary>
    /// <value>The payment amount in the specified currency.</value>
    /* <example>123.5</example> */
    [JsonPropertyName("amount")]
    public double Amount { get; set; }

    /// <summary>
    ///     The payment currency. 3 char ISO 4217 currency code.
    /// </summary>
    /// <value>The payment currency. 3 char ISO 4217 currency code.</value>
    /* <example>GBP</example> */
    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    /// <summary>
    ///     The date the payment was created in the system.
    /// </summary>
    /// <value>The date the payment was created in the system.</value>
    /* <example>2024-11-28T00:00Z</example> */
    [JsonPropertyName("createdDate")]
    public DateTime CreatedDate { get; set; }

    /// <summary>
    ///     Gets or Sets Status
    /// </summary>
    [JsonPropertyName("status")]
    public PaymentStatusOutput Status { get; set; }

    /// <summary>
    ///     The ID of the mandate to whom the payment belongs.
    /// </summary>
    /// <value>The ID of the mandate to whom the payment belongs.</value>
    /* <example>c61f1e0e-3f3e-459d-a4f1-5fa6c52b1921</example> */
    [JsonPropertyName("mandateId")]
    public Guid? MandateId { get; set; }

    /// <summary>
    ///     The reference that was set when creating the payment.
    /// </summary>
    /// <value>The reference that was set when creating the payment.</value>
    /* <example>Example Reference</example> */
    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    /// <summary>
    ///     The reference that was set when creating the payment, after normalization was applied.
    /// </summary>
    /// <value>The reference that was set when creating the payment, after normalization was applied.</value>
    /* <example>Example Adjusted Reference</example> */
    [JsonPropertyName("adjustedReference")]
    public string? AdjustedReference { get; set; }

    /// <summary>
    ///     Unique identifier defined by the sender of the payment.
    /// </summary>
    /// <value>Unique identifier defined by the sender of the payment.</value>
    /* <example>Example ID</example> */
    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    /// <summary>
    ///     Unique identifier defined by the sender of the payment.
    /// </summary>
    /// <value>Unique identifier defined by the sender of the payment.</value>
    /* <example>Example ID</example> */
    [JsonPropertyName("endToEndId")]
    public string? EndToEndId { get; set; }

    /// <summary>
    ///     The provider of the source account.
    /// </summary>
    /// <value>The provider of the source account.</value>
    /* <example>GB_TestBank</example> */
    [JsonPropertyName("providerId")]
    public string? ProviderId { get; set; }

    /// <summary>
    ///     Gets or Sets Date
    /// </summary>
    [JsonPropertyName("date")]
    public PaymentDate? Date { get; set; }

    /// <summary>
    ///     Gets or Sets Context
    /// </summary>
    [JsonPropertyName("context")]
    public PaymentRiskContext? Context { get; set; }

    /// <summary>
    ///     Id of the payment issued by the provider.
    /// </summary>
    /// <value>Id of the payment issued by the provider.</value>
    /* <example>472e651e-5a1e-424d-8098-23858bf03ad7</example> */
    [JsonPropertyName("providerPaymentId")]
    public string? ProviderPaymentId { get; set; }

    /// <summary>
    ///     Gets or Sets EndUser
    /// </summary>
    [JsonPropertyName("endUser")]
    public EndUserOutput? EndUser { get; set; }

    /// <summary>
    ///     Reference assigned to the payment by the client.  Allows the client to control an identifier that will not get sent
    ///     to the providers, for easier reconciliation or other purposes.
    /// </summary>
    /// <value>
    ///     Reference assigned to the payment by the client.  Allows the client to control an identifier that will not get
    ///     sent  to the providers, for easier reconciliation or other purposes.
    /// </value>
    /* <example>Example client assigned reference</example> */
    [JsonPropertyName("clientAssignedReference")]
    public string? ClientAssignedReference { get; set; }

    /// <summary>
    ///     Indicates the settlement it belongs to.
    /// </summary>
    /// <value>Indicates the settlement it belongs to.</value>
    [JsonPropertyName("forwardSettlementReference")]
    public string? ForwardSettlementReference { get; set; }

    /// <summary>
    ///     Gets or Sets PreselectedSource
    /// </summary>
    [JsonPropertyName("preselectedSource")]
    public PreselectedSourceOutput? PreselectedSource { get; set; }

    /// <summary>
    ///     Default: &#x60;\&quot;InstantPreferred\&quot;&#x60;                The execution type that should be used for the
    ///     payment.  * &#x60;Instant&#x60; - The payment will only be initiated if it can be done instantly. If a provider
    ///     that doesn&#39;t support Instant is selected, the payment will fail. Does not support specifying a future date of
    ///     execution. Only providers that support Instant payments will be shown in the provider selector. * &#x60;
    ///     InstantPreferred&#x60; - Initiate the payment instantly, if possible, or fallback to Standard SEPA if not
    ///     supported. All providers will be shown in the provider selector. If a date is specified, the execution method will
    ///     be treated as Standard. * &#x60;Standard&#x60; - The payment will be initiated as a Standard payment.
    /// </summary>
    /// <value>
    ///     Default: &#x60;\&quot;InstantPreferred\&quot;&#x60;                The execution type that should be used for
    ///     the payment.  * &#x60;Instant&#x60; - The payment will only be initiated if it can be done instantly. If a provider
    ///     that doesn&#39;t support Instant is selected, the payment will fail. Does not support specifying a future date of
    ///     execution. Only providers that support Instant payments will be shown in the provider selector. * &#x60;
    ///     InstantPreferred&#x60; - Initiate the payment instantly, if possible, or fallback to Standard SEPA if not
    ///     supported. All providers will be shown in the provider selector. If a date is specified, the execution method will
    ///     be treated as Standard. * &#x60;Standard&#x60; - The payment will be initiated as a Standard payment.
    /// </value>
    [JsonPropertyName("executionMethod")]
    public string? ExecutionMethod { get; set; }
}
#pragma warning restore CS8618