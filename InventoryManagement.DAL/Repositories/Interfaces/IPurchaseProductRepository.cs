using InventoryManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Repositories.Interfaces
{
    public interface IPurchaseProductRepository : IGenericRepository<PurchaseProduct>
    {
        public Task<IEnumerable<PurchaseProduct>> GetAll();
    }
}
