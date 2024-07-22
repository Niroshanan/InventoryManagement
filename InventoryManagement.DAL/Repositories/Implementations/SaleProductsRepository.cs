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
    public class SaleProductsRepository : GenericRepository<SaleProduct>, ISaleProductsRepository
    {
        private readonly ApplicationDbContext _db;
        public SaleProductsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
