using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WineSite.Core.Contracts;
using WineSite.Core.Services;
using WineSite.Data.Data;
using WineSite.Data.Data.Models;
 

namespace WineSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<WineShopDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("WineSite.Web")));
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
            
            builder.Services.AddScoped<IWineServices, WineServices>();
            builder.Services.AddScoped<IRecipeServices, RecipeServices>();
            builder.Services.AddScoped<IEventServices, EventServices>();
            builder.Services.AddScoped<IAdminServices, AdminServices>();
            builder.Services.AddScoped<IContactServices, ContactServices>();
            builder.Services.AddScoped<IUserServices, UserService>();

            builder.Services.AddMemoryCache();
            var app = builder.Build();

            
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

            
          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "Wine Details",
                 pattern: "/Wine/Details/{id}/{information}",
                 defaults: new {Controller = "Wine", Actions = "Details"}
               );

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Homes}/{action=Index}/{id?}"
                );

                app.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });

            app.Run();
        }
    }
}