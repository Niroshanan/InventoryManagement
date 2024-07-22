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
    public class SalesService : ISalesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddSale(SaleDTO saleDTO)
        {
            try
            {
                var sale = new Sale
                {
                    StoreId = saleDTO.StoreId,
                    CreatedAt = DateTime.Now,
                };

                await _unitOfWork.Sales.Add(sale);

                foreach (var item in saleDTO.ProductList)
                {
                    if(item.Quantity <= 0)
                    {
                        throw new Exception("Product quantity must be greater than 0.");
                    }
                    if(item.Quantity > _unitOfWork.StoreProducts.GetAvailableProductQuantity(saleDTO.StoreId, item.ProductId).Result)
                    {
                        throw new Exception("Product quantity is greater than available quantity.");
                    }
                    var saleProduct = new SaleProduct
                    {
                        SaleId = sale.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    };

                    await _unitOfWork.SaleProducts.Add(saleProduct);
                    await _unitOfWork.StoreProducts.DeductSaleQuantity(saleDTO.StoreId, item.ProductId, item.Quantity);
                }
                await _unitOfWork.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
