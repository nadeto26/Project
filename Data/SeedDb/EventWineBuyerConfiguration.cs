using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WineSite.Data.Models;

namespace WineSite.Data.SeedDb
{
    public class EventWineBuyerConfiguration : IEntityTypeConfiguration<EventWineBuyer>
    {
        public void Configure(EntityTypeBuilder<EventWineBuyer> builder)
        {
            builder
             .HasKey(e => new { e.EventId, e.WineId,e.BuyerId});
              
        }
    }
}
