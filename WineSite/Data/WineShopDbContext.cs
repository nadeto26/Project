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
            builder.ApplyConfiguration(new TypeConfiguration());
            builder.ApplyConfiguration(new WineConfiguration());
            builder.ApplyConfiguration(new WineBuyerConfiguration());
            builder.ApplyConfiguration(new TicketBuyerConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Events> Events { get; set; } = null!;
        public DbSet<WineBuyers> WineBuyers { get; set; } = null!;
        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<Type> Types { get; set; } = null!;
        public DbSet<Wine> Wines { get; set; } = null!;
        public DbSet<TicketBuyer> TicketBuyers { get; set; } = null!;
        public DbSet<TicketDelivery> TicketDeliveries { get; set; } = null!;
        public DbSet<Orders> Orders { get; set; } = null!;
        public DbSet<OrderWines> OrderWines { get; set; } = null!;
        public DbSet<WineDelivery> WineDeliveries { get; set; } = null!;


    }
}