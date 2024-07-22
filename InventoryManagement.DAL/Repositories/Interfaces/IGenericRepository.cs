using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(object id);
        Task Add(T entity);
        Task Delete(T entity);

    }
}
