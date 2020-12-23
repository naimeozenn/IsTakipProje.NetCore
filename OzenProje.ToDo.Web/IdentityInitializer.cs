﻿using Microsoft.AspNetCore.Identity;
using OzenProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzenProje.ToDo.Web
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole==null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }
            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole==null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" });
            }
            var adminUser = await userManager.FindByNameAsync("naime");
            if (adminUser==null)
            {
                AppUser user = new AppUser
                {
                    Name = "Naime",
                    Surname = "Ozen",
                    UserName = "naimeozen",
                    Email = "naimeozenn@hotmail.com"

                };
                await userManager.CreateAsync(user,"1");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
