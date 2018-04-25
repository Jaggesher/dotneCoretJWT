using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using dotnetCoreJWT.Models;

namespace dotnetCoreJWT.Data
{
    public class DbInitializer
    {
        public async static void Initialize(ApplicationDbContext _context,
            UserManager<ApplicationUser> _userManage, RoleManager<IdentityRole> _roleManager
            , ILogger<DbInitializer> _logger)
        {
            if (await _context.Users.AnyAsync())
            {
                return;
            }
            _logger.LogInformation("Create the role admin and user for application");

            var rl_1 = await _roleManager.CreateAsync(new IdentityRole { Name = "admin" });
            var rl_2 = await _roleManager.CreateAsync(new IdentityRole { Name = "user" });

            if (rl_1.Succeeded && rl_2.Succeeded)
            {
                _logger.LogDebug("Created the roles successfully");
            }
            else
            {
                _logger.LogDebug("Can't Create the roles");
            }


        }
    }
}