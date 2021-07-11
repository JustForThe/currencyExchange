using currencyExchangeService.Domain.Entities;
using currencyExchangeService.Domain.ValueObjects;
using currencyExchangeService.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using currencyExchangeService.Application.Common.Interfaces;

namespace currencyExchangeService.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.MarkupSettings.Any())
            {
                context.MarkupSettings.Add(new MarkupSetting
                {
                    Id =1,
                    MarkupSettingPercentage = 0.01m
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
