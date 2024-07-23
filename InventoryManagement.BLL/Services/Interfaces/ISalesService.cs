using InventoryManagement.BLL.DTOs;
using InventoryManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Services.Interfaces
{
    public interface ISalesService
    {
        Task AddSale(SaleDTO saleDTO);
        Task<IEnumerable<SalesProductDto>> GetAllSales();
        Task<IEnumerable<SalesProductDto>> GetSalesByStore(Guid storeId);
        Task<IEnumerable<SalesProductDto>> GetSalesByProduct(Guid productId);

    }
}
