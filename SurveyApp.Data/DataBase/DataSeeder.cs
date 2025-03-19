using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SurveyApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Data.DataBase
{
    public class DataSeeder
    {
        private readonly IServiceProvider _serviceProvider;

        public DataSeeder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task SeedAsync()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                if (!dbContext.Roles.Any())
                {
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AspNetRole>>();
                    await roleManager.CreateAsync(new AspNetRole { Name = "Admin" });
                    await roleManager.CreateAsync(new AspNetRole { Name = "User" });
                }

                if (!dbContext.Users.Any())
                {
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AspNetUser>>();
                    var user = new AspNetUser
                    {
                        UserName = "admin",
                        Name = "AdminName",
                        Surname = "AdminSurname",
                        Email = "admin@admin.com"
                    };

                    await userManager.CreateAsync(user, "Asd123**");
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
