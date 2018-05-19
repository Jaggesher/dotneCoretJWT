using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using dotnetCoreJWT.Models;
using System.Threading.Tasks;

namespace dotnetCoreJWT.Data
{
    public class DbInitializer
    {
        public static async Task Initialize( UserManager<ApplicationUser> _userManage, RoleManager<IdentityRole> _roleManager, ILogger<DbInitializer> _logger)
        {

            _logger.LogInformation("Creating Roles For Application");

            if (! await _roleManager.RoleExistsAsync("admin") )
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "admin" });
            }

            if (! await _roleManager.RoleExistsAsync("simpleUser"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "simpleUser" });
            }

            if(! await _roleManager.RoleExistsAsync("valueableUser"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "valueableUser" });
            }

            _logger.LogInformation("All Logs Are OK");

            _logger.LogInformation("Now Seeding Users");

            if (await _userManage.FindByNameAsync("admin") == null)
            {
                var user = new ApplicationUser { Email = "admin@gmail.com", UserName = "admin" };
                string password = "123456=Jk";
                await _userManage.CreateAsync(user, password);

                await _userManage.AddToRoleAsync(user,"admin");

            }
            

            if (await _userManage.FindByNameAsync("SimpleUser") == null)
            {
                var user = new ApplicationUser { Email = "simpleuser@gmail.com", UserName = "SimpleUser" };
                string password = "123456=Jk";
                await _userManage.CreateAsync(user, password);

                await _userManage.AddToRoleAsync(user,"simpleUser");

            }

            if( await _userManage.FindByNameAsync("ValueableUser") == null)
            {
                var user = new ApplicationUser { Email = "valueableuser@gmail.com", UserName = "ValueableUser" };
                string password = "123456=Jk";
                await _userManage.CreateAsync(user, password);

                await _userManage.AddToRoleAsync(user,"valueableUser");
            }

            _logger.LogInformation("All users Seems OK");

        }
    }
}