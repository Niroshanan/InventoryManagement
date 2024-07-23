using InventoryManagement.BLL.DTOs;
using InventoryManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Services.Interfaces
{
    public interface IStoreService
    {
        Task<IEnumerable<Store>> GetAllStores();
        Task<int> AddNewStore(StoreDto storeDto);
        Task EditStore(Guid id,StoreDto storeDto);
        Task<int> DeleteStore(Guid id);

        Task<IEnumerable<RemainigProductDTO>> GetRemainingStock(Guid? Id= null);
    }
}
