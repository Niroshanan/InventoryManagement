using InventoryManagement.DAL.Data;
using InventoryManagement.DAL.Entities;
using InventoryManagement.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Repositories.Implementations
{
    public class StoreProductRepository : GenericRepository<StoreProduct>, IStoreProductRepository
    {
        private readonly ApplicationDbContext _db;
        public StoreProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public Task<bool> IsRecordExist(Guid storeId, Guid productId)
        {
            return Task.FromResult(_db.StoreProducts.Any(sp => sp.StoreId == storeId && sp.ProductId == productId));
        }

        public Task<bool> AddPurchasedQuantity(Guid storeId, Guid productId, int quantity)
        {
            var storeProduct = _db.StoreProducts.FirstOrDefault(sp => sp.StoreId == storeId && sp.ProductId == productId);
            if (storeProduct != null)
            {
                storeProduct.Quantity += quantity;
                _db.StoreProducts.Update(storeProduct);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<bool> DeductSaleQuantity(Guid storeId, Guid productId, int quantity)
        {
            var storeProduct = _db.StoreProducts.FirstOrDefault(sp => sp.StoreId == storeId && sp.ProductId == productId);
            if (storeProduct != null)
            {
                storeProduct.Quantity -= quantity;
                _db.StoreProducts.Update(storeProduct);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<int> GetAvailableProductQuantity(Guid storeId, Guid productId)
        {
            var sp = _db.StoreProducts
                .Where(sp => sp.StoreId == storeId && sp.ProductId == productId)
                .GroupBy(sp => new { sp.ProductId, sp.StoreId })
                .Select(sp => new
                {
                    sp.Key.ProductId,
                    sp.Key.StoreId,
                    Quantity = sp.Sum(sp => sp.Quantity)
                })
                .FirstOrDefault();

            return Task.FromResult(sp?.Quantity ?? 0);
        }
    }
}
