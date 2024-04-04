using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WineSite.Data.Models;

namespace WineSite.Data.SeedDb
{
    public class WineBuyerConfiguration : IEntityTypeConfiguration<WineBuyer>
    {
        public void Configure(EntityTypeBuilder<WineBuyer> builder)
        {
            builder
             .HasKey(e => new {e.WineId,e.BuyerId});
              
        }
    }
}
