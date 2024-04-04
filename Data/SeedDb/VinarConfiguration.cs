using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WineSite.Data.Models;

namespace WineSite.Data.SeedDb
{
    public class VinarConfiguration : IEntityTypeConfiguration<Vinar>
    {
        public void Configure(EntityTypeBuilder<Vinar> builder)
        {
            var data = new SeedData();

            builder.HasData(new Vinar[] { data.Vinar });
        }
    }
}
