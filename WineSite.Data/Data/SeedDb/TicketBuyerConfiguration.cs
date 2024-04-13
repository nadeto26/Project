using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WineSite.Data.Data.Models;

namespace WineSite.Data.Data.SeedDb
{
    public class TicketBuyerConfiguration : IEntityTypeConfiguration<TicketBuyer>
    {
        public void Configure(EntityTypeBuilder<TicketBuyer> builder)
        {
            builder.HasKey(e => new { e.EventId, e.BuyerId });
        }
    }
}

