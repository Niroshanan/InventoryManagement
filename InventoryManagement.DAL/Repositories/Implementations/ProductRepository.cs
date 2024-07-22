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
    public class ProductRepository : GenericRepository<Product> ,IProductRepository 
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _db.Products.Include(p=> p.Category).ToListAsync();
        }
    }
}
