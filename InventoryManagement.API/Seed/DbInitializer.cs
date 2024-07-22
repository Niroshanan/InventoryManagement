using InventoryManagement.BLL.Utility;
using InventoryManagement.DAL.Data;
using InventoryManagement.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagement.API.Seed
{
    public class DbInitializer :IDbInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _dbContext;
        public DbInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }
        public async Task SeedRolesAndUsers()
        {
            string[] roleNames = { SD.Manager, SD.Operator , SD.SuperAdmin};

            foreach (var roleName in roleNames)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            string username = "superadmin";
            string email = "superadmin@example.com";
            string password = "Superadmin@123";
            if (await _userManager.FindByEmailAsync(email) == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = username,
                    Email = email,
                    EmailConfirmed = true,
                };
                IdentityResult result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, SD.SuperAdmin);
                }
            } else {
                ApplicationUser user = await _userManager.FindByEmailAsync(email);
                await _userManager.AddToRoleAsync(user, SD.SuperAdmin);
            }
        }
    }
}
