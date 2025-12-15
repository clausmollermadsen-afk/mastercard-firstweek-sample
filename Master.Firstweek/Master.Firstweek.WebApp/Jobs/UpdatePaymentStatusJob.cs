using Master.Firstweek.WebApp.Service;

namespace Master.Firstweek.WebApp.Jobs;

/// <summary>
///     Hangfire job that updates payment statuses.
/// </summary>
public class UpdatePaymentStatusJob
{
    private readonly PaymentService _paymentService;

    /// <summary>
    ///     Constructor with dependency injection for PaymentService.
    /// </summary>
    /// <param name="paymentService">The payment service to use for updating statuses.</param>
    public UpdatePaymentStatusJob(PaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    /// <summary>
    ///     Executes the job to update payment statuses.
    /// </summary>
    public async Task ExecuteAsync()
    {
        await _paymentService.UpdatePaymentStatusesAsync();
    }
}