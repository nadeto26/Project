using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WineSite.Data.Models;

namespace WineSite.Data.SeedDb
{
    public class WineConfiguration:IEntityTypeConfiguration<Wine>
    {
        public void Configure(EntityTypeBuilder<Wine> builder)
        {
            builder
               .HasOne(h => h.Type)
               .WithMany(c => c.Wines)
               .HasForeignKey(h => h.TypeId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(h => h.Vinar)
                .WithMany(a => a.Wines)
                .HasForeignKey(h => h.VinarId)
                .OnDelete(DeleteBehavior.Restrict);

        

            var data = new SeedData();

            builder.HasData(new Wine[] { data.FirstWine,data.SecondWine,data.ThirdWine});
        }
    }
}
