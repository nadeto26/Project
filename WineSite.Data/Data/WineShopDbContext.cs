using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WineSite.Data.Data.Models;
using WineSite.Data.Data.SeedDb;
using Type = WineSite.Data.Data.Models.Type;

namespace WineSite.Data.Data
{
    public class WineShopDbContext : IdentityDbContext<ApplicationUser>
    {
        private bool _seedDb;
        public WineShopDbContext(DbContextOptions<WineShopDbContext> options, bool seedDb = true)
            : base(options)
        {
            _seedDb = seedDb;
            //if (Database.IsRelational())
            //{
            //    Database.Migrate();
            //}
            //else
            //{
            //    Database.EnsureCreated();
            //}
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
             
               builder.Entity<TicketBuyer>()
               .HasKey(t => new { t.BuyerId, t.EventId });
                builder.ApplyConfiguration(new TicketBuyerConfiguration());
                builder.ApplyConfiguration(new UserConfiguration());
                builder.ApplyConfiguration(new TypeConfiguration());
                builder.ApplyConfiguration(new WineConfiguration());
                builder.ApplyConfiguration(new WineBuyerConfiguration());
                
            
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
        public DbSet<Messages> Messages { get; set; } = null!;

    }
}