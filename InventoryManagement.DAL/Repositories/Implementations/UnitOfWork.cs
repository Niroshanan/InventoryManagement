using InventoryManagement.DAL.Data;
using InventoryManagement.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IProductRepository Products { get;}
        public IPurchaseRepository Purchases { get; }
        public IPurchaseProductRepository PurchaseProducts { get; }
        public ISaleRepository Sales { get; }
        public ISaleProductsRepository SaleProducts { get; }
        public IStoreRepository Stores { get; }
        public IStoreProductRepository StoreProducts { get; }
        public ICategoryRepository Categories { get; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _db = dbContext;
            Products = new ProductRepository(_db);
            Purchases = new PuchaseRepository(_db);
            PurchaseProducts = new PurchaseProductRepository(_db);
            Sales = new SaleRepository(_db);
            SaleProducts = new SaleProductsRepository(_db);
            Stores = new StoreRepository(_db);
            StoreProducts = new StoreProductRepository(_db);
            Categories = new CategoryRepository(_db);
        }

        public Task<int> SaveChanges()
        {
            return _db.SaveChangesAsync();
        }

    }
}
