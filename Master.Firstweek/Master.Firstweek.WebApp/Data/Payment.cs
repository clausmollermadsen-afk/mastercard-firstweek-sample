using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Master.Firstweek.WebApp.Data;

public class Payment : EntityBase<Payment>
{
    public required string Status { get; set; }

    public Bill? Bill { get; set; }

    public required long FK_BillId { get; set; }

    public required string FlowUrl { get; set; }

    public required Guid PaymentId { get; set; }

    public required string Name { get; set; }

    public required string CprNumber { get; init; }

    public new void Configure(EntityTypeBuilder<Payment> builder)
    {
        base.Configure(builder);
        builder.HasOne(payment => payment.Bill)
            .WithMany(c => c.Payments)
            .HasForeignKey(bill => bill.FK_BillId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}