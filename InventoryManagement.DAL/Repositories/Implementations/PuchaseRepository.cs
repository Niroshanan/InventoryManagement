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
    public class PuchaseRepository : GenericRepository<Purchase>, IPurchaseRepository
    {
        private readonly ApplicationDbContext _db;

        public PuchaseRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<IEnumerable<Purchase>> GetAll()
        {
            try
            {
                return await _db.Purchases.ToListAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
