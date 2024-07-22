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
    public class SaleRepository : GenericRepository<Sale> , ISaleRepository
    {
        private readonly ApplicationDbContext _db;
        public SaleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
