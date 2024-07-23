using InventoryManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Repositories.Interfaces
{
    public interface IStoreRepository : IGenericRepository<Store>
    {
        Task<IEnumerable<Store>> GetAllStores();
        Task AddNewStoreAsync(Store store);
        Task EditStore(Store store);
    }
}
