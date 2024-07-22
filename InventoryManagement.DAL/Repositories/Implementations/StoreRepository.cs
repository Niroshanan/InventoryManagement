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
    public class StoreRepository : GenericRepository<Store> , IStoreRepository
    {
        private readonly ApplicationDbContext _db;
        public StoreRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
