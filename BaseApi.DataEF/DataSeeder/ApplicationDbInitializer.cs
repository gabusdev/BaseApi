using BaseApi.Core.Entities;
using BaseApi.Core.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;

namespace BaseApi.Api.AppServices.DataSeed
{
    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<User> userManager)
        {
            if (userManager.FindByEmailAsync("admin@mail.com").Result == null)
            {
                var user = new User
                {
                    UserName = "Administrator",
                    Email = "admin@mail.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "Temp_123").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Enum.GetName(RoleEnum.Administrator)).Wait();
                }
            }

            if (userManager.FindByEmailAsync("guest@mail.com").Result == null)
            {
                var user = new User
                {
                    UserName = "Guest",
                    Email = "guest@mail.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "Temp_123").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Enum.GetName(RoleEnum.User)).Wait();
                }
            }
        }
    }
}
