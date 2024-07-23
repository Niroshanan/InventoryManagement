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
    public class StoreService : IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StoreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddNewStore(StoreDto storeDto)
        {
            try
            {
                await _unitOfWork.Stores.AddNewStoreAsync(_mapper.Map<Store>(storeDto));
                return await _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task EditStore(Guid id, StoreDto storeDto)
        {
            try
            {
                var store = await _unitOfWork.Stores.GetById(id) ?? throw new Exception("Store not found");
                _mapper.Map(storeDto, store);
                await _unitOfWork.Stores.EditStore(store);
                await _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<IEnumerable<Store>> GetAllStores()
        {
            try
            {
                return _unitOfWork.Stores.GetAllStores();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteStore(Guid id)
        {
            var store = await _unitOfWork.Stores.GetById(id);
            if (store == null)
            {
                throw new Exception("Store not found");
            }
            try
            {
                await _unitOfWork.Stores.Delete(store);
                return await _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<RemainigProductDTO>> GetRemainingStock(Guid? Id = null)
        {
            try
            {
                var storeProducts = await _unitOfWork.StoreProducts.GetRemainingProductQuantity(Id);
                var storeProductDtos = _mapper.Map<IEnumerable<RemainigProductDTO>>(storeProducts);
                return storeProductDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
