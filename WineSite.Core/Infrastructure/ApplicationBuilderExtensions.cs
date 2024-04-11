using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WineSite.Data.Data.Models;

namespace WineSite.Core.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var services = scopedServices.ServiceProvider;

            var usermanger = services.GetRequiredService<UserManager<ApplicationUser>>();

            var rolemanger = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                if (await rolemanger.RoleExistsAsync("Adminstrator"))
                {
                    return;
                }

                var role = new IdentityRole { Name = "Administrator" };
                await rolemanger.CreateAsync(role);
                var admin = await usermanger.FindByNameAsync("nadezhda.karapetrova@pmggd.bg");

                await usermanger.AddToRoleAsync(admin, role.Name);
            })
                .GetAwaiter()
                .GetResult();

            return app;

        }
                

            
        }
    }

