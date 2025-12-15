using System.Text.Json.Serialization;

namespace Master.Firstweek.Client.Model;

public class PaymentDate
{
    /// <summary>
    ///     The requested date for payment execution. Note: If a non-banking day is chosen, the next banking day will be chosen
    ///     instead.
    /// </summary>
    /// <value>
    ///     The requested date for payment execution. Note: If a non-banking day is chosen, the next banking day will be
    ///     chosen  instead.
    /// </value>
    /* <example>Wed Feb 21 00:00:00 UTC 2024</example> */
    [JsonPropertyName("requestedDate")]
    public DateOnly? RequestedDate { get; set; }

    /// <summary>
    ///     The actual date for payment execution. Could be different from requested date depending on payment rail.
    /// </summary>
    /// <value>The actual date for payment execution. Could be different from requested date depending on payment rail.</value>
    /* <example>Thu Feb 22 00:00:00 UTC 2024</example> */
    [JsonPropertyName("actualDate")]
    public DateOnly? ActualDate { get; set; }
}