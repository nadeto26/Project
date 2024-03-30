using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WineSite.Data.Models;
using Type = WineSite.Data.Models.Type;

namespace WineSite.Data.SeedDb
{
    public class TypeConfiguration : IEntityTypeConfiguration<Type>
    {
        public void Configure(EntityTypeBuilder<Type> builder)
        {
            var data = new SeedData();

            builder.HasData(new Type[] { data.RedWine,data.RoseWine,data.WhiteWine });
        }
    }
}
