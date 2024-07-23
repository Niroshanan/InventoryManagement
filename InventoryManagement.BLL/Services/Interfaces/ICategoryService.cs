using InventoryManagement.BLL.DTOs;
using InventoryManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<int> AddNewCategory(CategoryDTO categoryDto);
        Task<int> DeleteCategory(Guid id);

        Task UpdateCategory(Guid id, CategoryDTO categoryDto);
    }
}
