using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Master.Firstweek.WebApp.Data;

public class Bill : EntityBase<Bill>
{
    public required double Amount { get; init; }

    public required DateTime FromDate { get; init; }

    public required DateTime ToDate { get; init; }

    public required string FK_UserId { get; init; }

    public required string Status { get; init; }

    public List<Payment> Payments { get; set; } = new();

    public required ApplicationUser ApplicationUser { get; set; }

    public new void Configure(EntityTypeBuilder<Bill> builder)
    {
        base.Configure(builder);
        builder.HasOne(bill => bill.ApplicationUser)
            .WithMany(c => c.Bills)
            .HasForeignKey(bill => bill.FK_UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}