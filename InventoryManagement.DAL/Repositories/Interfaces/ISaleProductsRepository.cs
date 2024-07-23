using InventoryManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Repositories.Interfaces
{
    public interface ISaleProductsRepository : IGenericRepository<SaleProduct>
    {
        Task<IEnumerable<SaleProduct>> GetAllSaleItems();

        Task<IEnumerable<SaleProduct>> GetSaleItemsByStore(Guid storeId);
        Task<IEnumerable<SaleProduct>> GetSaleItemsByProduct(Guid productId);
    }
}
