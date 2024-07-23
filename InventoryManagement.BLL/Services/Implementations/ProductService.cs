using AutoMapper;
using InventoryManagement.BLL.DTOs;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddProduct(ProductDTO productDto)
        {
            if (productDto.Price <= 0)
            {
                throw new Exception("Price cannot be negative");
            }
            Product product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId
            };
            await _unitOfWork.Products.Add(product);
            await _unitOfWork.SaveChanges();
        }

        public async Task<int> DeleteProdcut(Guid id)
        {
            var entity = await _unitOfWork.Products.GetById(id);
            if (entity == null)
            {
                throw new Exception("Product not found");
            }
            try
            {
                await _unitOfWork.Products.Delete(entity);
                return await _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _unitOfWork.Products.GetAllProducts();

            return products;
        }

        public async Task UpdateProduct(Guid id, ProductDTO productDto)
        {
            var entity = await _unitOfWork.Products.GetById(id);
            if (entity == null)
            {
                throw new Exception("Product not found");
            }
            _mapper.Map(productDto, entity);
            await _unitOfWork.Products.UpdateProduct(entity);
            await _unitOfWork.SaveChanges();
        }
    }
}
