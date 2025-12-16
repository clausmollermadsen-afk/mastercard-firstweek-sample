using Master.Firstweek.WebApp.Data;
using Master.Firstweek.WebApp.Service;
using Microsoft.AspNetCore.Components;

namespace Master.Firstweek.WebApp.Components.Pages;

public partial class AddPayment : ComponentBase
{
    private string? _cprNumber;

    private string? _name;

    [Inject] public required BillService BillService { get; set; }

    [Inject] public required PaymentService PaymentService { get; set; }

    [Inject] public required NavigationManager NavigationManager { get; set; }

    private Bill? Bill { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Bill = await BillService.GetBill(BillId);
    }

    private async Task AddPaymentAsync()
    {
        if (Bill != null && _cprNumber != null && _name != null)
        {
            await PaymentService.AddPaymentAsync(BillId, _cprNumber, _name);
            NavigationManager.NavigateTo("/Bill");
        }
    }
}