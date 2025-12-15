using System.Text.Json.Serialization;

namespace Master.Firstweek.Client.Model;

#pragma warning disable CS8618
public class PaymentStatusOutput
{
    /// <summary>
    ///     The payment status code.  * &#x60;PREPARING&#x60; - The payment request details have been captured and the payment
    ///     is ready to be authorized by the Payer. * &#x60;AUTHORIZING&#x60; - The Payer is going through the payment
    ///     authorization journey. * &#x60;PROVIDER_PROCESSING&#x60; - The ASPSP received the payment request. Aiia is awaiting
    ///     confirmation that the payment has been initiated. * &#x60;PENDING&#x60; - The ASPSP placed the payment in a pending
    ///     state. Further action from the Payer may be required. * &#x60;INITIATED&#x60; - The ASPSP validated and accepted
    ///     the payment request. The payment has been scheduled for the provided payment date, or as soon as possible. * &#x60;
    ///     PAYMENT_EXECUTED_DEBITED&#x60; - The payment has been settled and debited from the Payer&#39;s account. * &#x60;
    ///     PAYMENT_EXECUTED_CREDITED&#x60; - The payment has been settled and we received confirmation that it was credited to
    ///     the Payee&#39;s account. * &#x60;CANCELLED&#x60; - The Payer either cancelled the payment at the authorization
    ///     stage, did not proceed before the payment expired, or cancelled a scheduled future payment before it reached its
    ///     execution date. The payment has not been executed. * &#x60;FAILED&#x60; - The payment failed. More information
    ///     about the cause of the failure may be available in the details.code and details.reason fields of the status object
    ///     * &#x60;UNKNOWN&#x60; - Aiia&#39;s access to refresh the payment status at the ASPSP has expired. Refer to the
    ///     details.lastKnownStatus field to find the last known status of the payment, before access was lost. For
    ///     confirmation of payment execution, perform reconciliation against transactions in the destination account. * &#x60;
    ///     AUTHORIZATION_FLOW_INCOMPLETE&#x60; - The payment authorization URL expired, or the Payer left the payment
    ///     authorization page. The payment authorization has not been completed. * &#x60;FORWARD_SETTLEMENT_INITIATED&#x60; -
    ///     Updated when payment has been compiled as part of a daily batch reconciliation and issued to the client/merchant.
    /// </summary>
    /// <value>
    ///     The payment status code.  * &#x60;PREPARING&#x60; - The payment request details have been captured and the
    ///     payment is ready to be authorized by the Payer. * &#x60;AUTHORIZING&#x60; - The Payer is going through the payment
    ///     authorization journey. * &#x60;PROVIDER_PROCESSING&#x60; - The ASPSP received the payment request. Aiia is awaiting
    ///     confirmation that the payment has been initiated. * &#x60;PENDING&#x60; - The ASPSP placed the payment in a pending
    ///     state. Further action from the Payer may be required. * &#x60;INITIATED&#x60; - The ASPSP validated and accepted
    ///     the payment request. The payment has been scheduled for the provided payment date, or as soon as possible. * &#x60;
    ///     PAYMENT_EXECUTED_DEBITED&#x60; - The payment has been settled and debited from the Payer&#39;s account. * &#x60;
    ///     PAYMENT_EXECUTED_CREDITED&#x60; - The payment has been settled and we received confirmation that it was credited to
    ///     the Payee&#39;s account. * &#x60;CANCELLED&#x60; - The Payer either cancelled the payment at the authorization
    ///     stage, did not proceed before the payment expired, or cancelled a scheduled future payment before it reached its
    ///     execution date. The payment has not been executed. * &#x60;FAILED&#x60; - The payment failed. More information
    ///     about the cause of the failure may be available in the details.code and details.reason fields of the status object
    ///     * &#x60;UNKNOWN&#x60; - Aiia&#39;s access to refresh the payment status at the ASPSP has expired. Refer to the
    ///     details.lastKnownStatus field to find the last known status of the payment, before access was lost. For
    ///     confirmation of payment execution, perform reconciliation against transactions in the destination account. * &#x60;
    ///     AUTHORIZATION_FLOW_INCOMPLETE&#x60; - The payment authorization URL expired, or the Payer left the payment
    ///     authorization page. The payment authorization has not been completed. * &#x60;FORWARD_SETTLEMENT_INITIATED&#x60; -
    ///     Updated when payment has been compiled as part of a daily batch reconciliation and issued to the client/merchant.
    /// </value>
    [JsonPropertyName("code")]
    public string Code { get; set; }

    /// <summary>
    ///     A historical list of all the status changes of the payment.
    /// </summary>
    /// <value>A historical list of all the status changes of the payment.</value>
    [JsonPropertyName("events")]
    public List<PaymentStatusChangeEvent>? Events { get; set; }

    /// <summary>
    ///     Gets or Sets Details
    /// </summary>
    [JsonPropertyName("details")]
    public PaymentStatusDetailsOutput? Details { get; set; }
}

#pragma warning restore CS8618