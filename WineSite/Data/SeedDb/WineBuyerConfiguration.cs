using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WineSite.Data.Models;

namespace WineSite.Data.SeedDb
{
    public class WineBuyerConfiguration : IEntityTypeConfiguration<WineBuyers>
    {
        public void Configure(EntityTypeBuilder<WineBuyers> builder)
        {
            builder
             .HasKey(e => new { e.WineId, e.BuyerId });
        }
    }
}
