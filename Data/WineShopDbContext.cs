using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WineSite.Data.Models;
using WineSite.Data.SeedDb;
using Type = WineSite.Data.Models.Type;

namespace WineSite.Data
{
    public class WineShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public WineShopDbContext(DbContextOptions<WineShopDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new VinarConfiguration());
            builder.ApplyConfiguration(new TypeConfiguration());
            builder.ApplyConfiguration(new WineConfiguration());
            builder.ApplyConfiguration(new EventWineBuyerConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Events> Events { get; set; } = null!;
        public DbSet<EventWineBuyer> EventWineBuyers { get; set; } = null!;
        public DbSet<MoreInformation> MoreInformation { get; set; } = null!;
        public DbSet<Type> Types { get; set; } = null!;
        public DbSet<Vinar> Vinar { get; set; } = null!;
        public DbSet<Wine> Wines { get; set; } = null!;



    }
}