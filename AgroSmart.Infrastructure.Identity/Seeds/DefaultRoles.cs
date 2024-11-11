using AgroSmart.Core.Application.Enums;
using AgroSmart.Infraestructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;


namespace AgroSmart.Infraestructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {            
            await roleManager.CreateAsync(new IdentityRole(Roles.Developer.ToString()));            
            await roleManager.CreateAsync(new IdentityRole(Roles.Client.ToString()));
        }
    }
}
