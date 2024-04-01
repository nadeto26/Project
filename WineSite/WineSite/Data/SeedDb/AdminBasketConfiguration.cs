using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WineSite.Data.Models;

namespace WineSite.Data.SeedDb
{
    public class AdminBasketConfiguration : IEntityTypeConfiguration<AdminTicketBasket>
    {
        public void Configure(EntityTypeBuilder<AdminTicketBasket> builder)
        {
            builder
             .HasKey(e => new { /*e.TicketBuyerId,*/ e.TicketDeliveryId });

        }
    }
    
}

