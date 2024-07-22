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
    public class PurchaseService : IPurchaseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddPurchase(PurchaseDTO purchaseDTO)
        {
            try
            {
                var purchase = new Purchase
                {
                    StoreId = purchaseDTO.StoreId,
                    CreatedAt = DateTime.Now,
                };

                await _unitOfWork.Purchases.Add(purchase);

                foreach (var item in purchaseDTO.ProductList)
                {
                    var purchaseProduct = new PurchaseProduct
                    {
                        PurchaseId = purchase.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        BuyingPrice = item.BuyingPrice,
                    };

                    bool recordExist = await _unitOfWork.StoreProducts.IsRecordExist(purchaseDTO.StoreId, item.ProductId);
                    if (recordExist)
                    {
                        await _unitOfWork.StoreProducts.AddPurchasedQuantity(purchaseDTO.StoreId, item.ProductId, item.Quantity);
                    }
                    else
                    {
                        var storeProduct = new StoreProduct
                        {
                            ProductId = item.ProductId,
                            StoreId = purchaseDTO.StoreId,
                            Quantity = item.Quantity,
                        };
                        await _unitOfWork.StoreProducts.Add(storeProduct);
                    }

                    await _unitOfWork.PurchaseProducts.Add(purchaseProduct);
                }

                await _unitOfWork.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while processing the purchase.", ex);
            }
        }

    }
}
