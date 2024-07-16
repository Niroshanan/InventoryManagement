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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StoreProduct>().HasKey(sp => new { sp.StoreId, sp.ProductId });

            Guid electronicsCategoryId = Guid.NewGuid();
            Guid clothingCategoryId = Guid.NewGuid();
            Guid groceryCategoryId = Guid.NewGuid();

            Guid productId1 = Guid.NewGuid();
            Guid productId2 = Guid.NewGuid();
            Guid productId3 = Guid.NewGuid();
            Guid productId4 = Guid.NewGuid();
            Guid productId5 = Guid.NewGuid();

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
