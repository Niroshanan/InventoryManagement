using InventoryManagement.BLL.Services.Interfaces;
using InventoryManagement.DAL.Entities;
using InventoryManagement.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _genericRepository;
        public ProductService(IUnitOfWork genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _genericRepository.Products.GetAllProducts();

        }
    }
}
