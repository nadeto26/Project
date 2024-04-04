using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WineSite.Data.Models;

namespace WineSite.Data.SeedDb
{
    public class TicketBuyerConfiguration : IEntityTypeConfiguration<TicketBuyer>
    {
        public void Configure(EntityTypeBuilder<TicketBuyer> builder)
        {
            builder
             .HasKey(e => new { e.EventId, e.BuyerId });

        }
    }
}

