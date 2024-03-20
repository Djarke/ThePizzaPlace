using Microsoft.AspNetCore.Identity;

namespace ThePizzaPlace.Data
{
    public class IdentitySeedData
    {
        public static async Task Initialize(ThePizzaPlaceContext context, 
        UserManager<IdentityUser> userManager, 
        RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            string adminRole = "Admin";
            string memberRole = "Member";
            string passwordWall = "P4ssword!";

            if (await roleManager.FindByNameAsync(adminRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            if (await roleManager.FindByNameAsync(memberRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(memberRole));
            }

            if (await userManager.FindByNameAsync("bigladdannyboi@gmail.com") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "bigladdannyboi@gmail.com",
                    Email = "bigladdannyboi@gmail.com",
                    PhoneNumber = "07514 617048"
                };
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, passwordWall);
                    await userManager.AddToRoleAsync(user, adminRole);
                }
            }

            if (await userManager.FindByNameAsync("bigsquadforthebigman@gmail.com") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "bigsquadforthebigman@gmail.com",
                    Email = "bigsquadforthebigman@gmail.com",
                    PhoneNumber = "07514 617048"
                };
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, passwordWall);
                    await userManager.AddToRoleAsync(user, memberRole);
                }
            }

        }
    }
}
