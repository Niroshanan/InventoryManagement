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
    public class StoreRepository : GenericRepository<Store>, IStoreRepository
    {
        private readonly ApplicationDbContext _db;
        public StoreRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task AddNewStoreAsync(Store store)
        {
            await _db.Stores.AddAsync(store);
        }

        public async Task EditStore(Store store)
        {
            try {                 
                _db.Stores.Update(store);
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Store>> GetAllStores()
        {
            return await _db.Stores.ToListAsync();
        }
    }
}
