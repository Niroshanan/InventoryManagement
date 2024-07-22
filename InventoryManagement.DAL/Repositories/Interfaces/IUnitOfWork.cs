using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IPurchaseRepository Purchases { get; }
        IPurchaseProductRepository PurchaseProducts { get; }
        ISaleRepository Sales { get; }
        ISaleProductsRepository SaleProducts { get; }
        IStoreRepository Stores { get; }
        IStoreProductRepository StoreProducts { get; }
        Task<int> SaveChanges();
    }
}
