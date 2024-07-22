using InventoryManagement.BLL.DTOs;
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
    }
}
