using InventoryManagement.DAL.Data;
using InventoryManagement.DAL.Entities;
using InventoryManagement.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Repositories.Implementations
{
    public class SaleProductsRepository : GenericRepository<SaleProduct>, ISaleProductsRepository
    {
        private readonly ApplicationDbContext _db;
        public SaleProductsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<SaleProduct>> GetAllSaleItems()
        {
            var saleItems = await GetSaleProductQuery().ToListAsync();
            return saleItems;
        }

        public async Task<IEnumerable<SaleProduct>> GetSaleItemsByProduct(Guid productId)
        {
            var saleItems = await GetSaleProductQuery()
                .Where(sp => sp.ProductId == productId)
                .ToListAsync();
            return saleItems;
        }

        public async Task<IEnumerable<SaleProduct>> GetSaleItemsByStore(Guid storeId)
        {
            var saleItems = await GetSaleProductQuery()
                .Where(sp => sp.Sale.StoreId == storeId)
                .ToListAsync();
            return saleItems;
        }

        private IQueryable<SaleProduct> GetSaleProductQuery()
        {
            return _db.SaleProducts
                .Include(sp => sp.Product).ThenInclude(p => p.Category)
                .Include(sp => sp.Sale).ThenInclude(s => s.Store);
        }
    }
}
