 
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WineSite.Contracts;
using WineSite.Data;
using WineSite.Data.Models;
using WineSite.Infrastructure;
using WineSite.Services;

namespace WineSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<WineShopDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddScoped<UserManager<ApplicationUser>>();
            builder.Services.AddScoped<SignInManager<ApplicationUser>>();
            builder.Services.AddTransient<IApplicationUserService,ApplicationUserService>();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

            })
                  .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<WineShopDbContext>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IVinarServices, VinarServices>();
            builder.Services.AddScoped<IWineServices, WineServices>();

            var app = builder.Build();
            app.SeedAdmin();

            if (app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
                app.UseHsts();
               
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            app.Run();
        }
    }
}