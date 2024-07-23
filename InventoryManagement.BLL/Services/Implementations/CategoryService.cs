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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork ,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddNewCategory(CategoryDTO categoryDto)
        {
            try
            {
                await _unitOfWork.Categories.Add(new Category
                {
                    Name = categoryDto.CategoryName,
                    Description = categoryDto.Description
                });

                return await _unitOfWork.SaveChanges(); ;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> DeleteCategory(Guid id)
        {
            var entity = await _unitOfWork.Categories.GetById(id);
            if (entity == null)
            {
                throw new Exception("Category not found");
            }
            try
            {
                await _unitOfWork.Categories.Delete(entity);
                return await _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            try
            {
                return (await _unitOfWork.Categories.GetAllCategories());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateCategory(Guid id, CategoryDTO categoryDto)
        {
            var entity = await _unitOfWork.Categories.GetById(id);
            if (entity == null)
            {
                throw new Exception("Category not found");
            }
            _mapper.Map(categoryDto, entity);
            await _unitOfWork.Categories.UpdateCategory(entity);
            await _unitOfWork.SaveChanges();

        }
    }
}
