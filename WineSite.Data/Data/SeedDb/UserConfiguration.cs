using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WineSite.Data.Data.Models;

namespace WineSite.Data.Data.SeedDb
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var data = new SeedData();

            builder.HasData(new ApplicationUser[] {data.GuestUser });
        }
    }
}
