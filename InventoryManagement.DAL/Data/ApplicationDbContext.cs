using InventoryManagement.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreProduct> StoreProducts { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<PurchaseProduct> PurchaseProducts { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StoreProduct>().HasKey(sp => new { sp.StoreId, sp.ProductId });
            modelBuilder.Entity<PurchaseProduct>().HasKey(pp => new { pp.PurchaseId, pp.ProductId });
            modelBuilder.Entity<SaleProduct>().HasKey(sp => new { sp.SaleId, sp.ProductId });

            Guid storeId1 = Guid.NewGuid();
            Guid storeId2 = Guid.NewGuid();

            Guid electronicsCategoryId = Guid.NewGuid();
            Guid clothingCategoryId = Guid.NewGuid();
            Guid groceryCategoryId = Guid.NewGuid();

            Guid productId1 = Guid.NewGuid();
            Guid productId2 = Guid.NewGuid();
            Guid productId3 = Guid.NewGuid();
            Guid productId4 = Guid.NewGuid();
            Guid productId5 = Guid.NewGuid();

            modelBuilder.Entity<Store>().HasData(
                new Store { Id = storeId1, Name = "Store 1", Location = "Location 1" },
                new Store { Id = storeId2, Name = "Store 2", Location = "Location 2" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = electronicsCategoryId, Name = "Electronics", Description = "asd" },
                new Category { Id = clothingCategoryId, Name = "Clothing", Description = "asd" },
                new Category { Id = groceryCategoryId, Name = "Grocery", Description = "asd" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = productId1, Name = "Laptop", Price = 1000, CategoryId = electronicsCategoryId },
                new Product { Id = productId2, Name = "T-shirt", Price = 20, CategoryId = clothingCategoryId },
                new Product { Id = productId3, Name = "Rice", Price = 10, CategoryId = groceryCategoryId },
                new Product { Id = productId4, Name = "Mobile Phone", Price = 500, CategoryId = electronicsCategoryId },
                new Product { Id = productId5, Name = "Jeans", Price = 50, CategoryId = clothingCategoryId }
            );

        }
    }
}
