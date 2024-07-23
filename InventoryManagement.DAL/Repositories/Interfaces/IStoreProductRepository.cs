using InventoryManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Repositories.Interfaces
{
    public interface IStoreProductRepository : IGenericRepository<StoreProduct>
    {
        Task<bool> IsRecordExist(Guid storeId, Guid productId);

        Task<bool> AddPurchasedQuantity(Guid storeId, Guid productId, int quantity);
        Task<bool> DeductSaleQuantity(Guid storeId, Guid productId, int quantity);

        Task<int> GetAvailableProductQuantity(Guid storeId, Guid productId);

        Task<IEnumerable<StoreProduct>> GetRemainingProductQuantity(Guid? StoreId = null);
    }
}
