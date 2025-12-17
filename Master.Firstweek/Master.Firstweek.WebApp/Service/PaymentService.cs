using Master.Firstweek.Client.Clients;
using Master.Firstweek.Client.Model;
using Master.Firstweek.WebApp.Configurtion;
using Master.Firstweek.WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Master.Firstweek.WebApp.Service;

/// <summary>
///     Service for managing payments and updating their statuses.
/// </summary>
public class PaymentService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<PaymentService> _logger;
    private readonly OpenBankingConfiguration _openBankingConfiguration;
    private readonly PaymentsClient _paymentsClient;

    /// <summary>
    ///     Initializes a new instance of the <see cref="PaymentService" /> class.
    /// </summary>
    public PaymentService(
        ApplicationDbContext context,
        PaymentsClient paymentsClient,
        OpenBankingConfiguration openBankingConfiguration,
        ILogger<PaymentService> logger)
    {
        _context = context;
        _paymentsClient = paymentsClient;
        _openBankingConfiguration = openBankingConfiguration;
        _logger = logger;
    }

    /// <summary>
    ///     Adds a payment for a bill and user.
    /// </summary>
    /// <param name="billId">The bill ID.</param>
    /// <param name="cprNumber">The CPR number of the payer.</param>
    /// <param name="name">The name of the payer.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task AddPaymentAsync(long billId, string cprNumber, string name,
        CancellationToken cancellationToken = default)
    {
        var bill = await _context.Bills
            .Include(x => x.ApplicationUser)
            .SingleOrDefaultAsync(b => billId == b.Id, cancellationToken);

        if (bill == null) throw new ArgumentException("Bill is not found");

        var createResult = await _paymentsClient.CreatePaymentAsync(
            new CreateAcceptPaymentDanishDomesticCreditTransferInstantInput
            {
                PaymentRail = "DanishDomesticCreditTransferInstant",
                DestinationId = _openBankingConfiguration.DestinationId,
                RedirectUrl = "http://localhost:5239/Bill",
                ClientAssignedReference = "Example client assigned reference",
                Language = "en-US",
                ThemeId = "ThemeId",
                Currency = "DKK",
                Reference = "Example Reference",
                Amount = bill.Amount,
                MessageToPayer = $"{bill.FromDate:yyyyMMdd}-{bill.ToDate:yyyyMMdd}",
                EndUser = new DanishDomesticCreditTransferInstantEndUser
                {
                    Id = cprNumber,
                    FullName = name,
                    Address = new DanishDomesticCreditTransferInstantPaymentAddressInput
                    {
                        AddressLines = new List<string> { bill.ApplicationUser.Address }
                    }
                }
            }, cancellationToken);

        await createResult.Match(
            async paymentResult =>
            {
                await _context.Payments.AddAsync(new Payment
                {
                    FK_BillId = bill.Id,
                    Bill = bill,
                    Status = "Created",
                    FlowUrl = paymentResult.FlowUrl,
                    PaymentId = paymentResult.PaymentId,
                    Name = name,
                    CprNumber = cprNumber
                }, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            },
            errorResponse =>
            {
                _logger.LogError("Failed to create payment with: {Errors} for bill with Id: {billId}", errorResponse,
                    billId);
                throw new Exception("Oprettelse af betaling mislykkedes");
            });
    }

    /// <summary>
    ///     Updates the status of all payments by querying the external payment provider.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task UpdatePaymentStatusesAsync(CancellationToken cancellationToken = default)
    {
        var payments = await _context.Payments.ToListAsync(cancellationToken);
        foreach (var payment in payments)
        {
            var getResult = await _paymentsClient.GetPaymentAsync(payment.PaymentId.ToString(), cancellationToken);
            await getResult.Match(
                async paymentResult =>
                {
                    payment.Status = paymentResult.Status.Code;
                    _context.Payments.Update(payment);
                    await _context.SaveChangesAsync(cancellationToken);
                },
                errorResponse =>
                {
                    _logger.LogError("Failed to get payment status with: {Errors} for payment with Id: {paymentId}",
                        errorResponse, payment.PaymentId);
                    // Do not throw here to allow other payments to continue updating
                    return Task.CompletedTask;
                });
        }
    }
}