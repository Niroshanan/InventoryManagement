using InventoryManagement.BLL.DTOs;
using InventoryManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task AddProduct(ProductDTO productDto);

        Task<int> DeleteProdcut(Guid id);

        Task UpdateProduct(Guid id, ProductDTO productDto);

    }
}
