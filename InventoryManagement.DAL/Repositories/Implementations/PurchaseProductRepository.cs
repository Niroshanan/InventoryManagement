
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
    public class PurchaseProductRepository : GenericRepository<PurchaseProduct>, IPurchaseProductRepository
    {
        private readonly ApplicationDbContext _db;

        public PurchaseProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<IEnumerable<PurchaseProduct>> GetAll()
        {
            try
            {
                return await _db.PurchaseProducts.ToListAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
