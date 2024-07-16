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
            string[] roleNames = { SD.Manager, SD.Operator};
            Guid storeId1 = Guid.NewGuid();
            Guid storeId2 = Guid.NewGuid();
            _dbContext.Stores.Add(new Store { Id = storeId1, Name = "Store 1", Location = "Location 1" });
            _dbContext.Stores.Add(new Store { Id = storeId2, Name = "Store 2", Location = "Location 2" });
            await _dbContext.SaveChangesAsync();


            foreach (var roleName in roleNames)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Add admin user if needed
            string adminEmail = "admin@example.com";
            string adminPassword = "Admin@123";
            if (await _userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new ApplicationUser { UserName = adminEmail, Email = adminEmail ,StoreId = storeId1 };
                await _userManager.CreateAsync(adminUser, adminPassword);
                await _userManager.AddToRoleAsync(adminUser, SD.Manager);
                await _userManager.AddToRoleAsync(adminUser, SD.Operator);
            }
        }
    }
}
