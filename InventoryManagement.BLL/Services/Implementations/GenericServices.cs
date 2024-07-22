using InventoryManagement.BLL.Services.Interfaces;
using InventoryManagement.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Services.Implementations
{
    public class GenericServices : IGenericServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public IProductService Products { get; private set; }
        public IPurchaseService Purchase { get; private set; }
        public ISalesService Sales { get; private set; }

        public GenericServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Products = new ProductService(_unitOfWork);
            Purchase = new PurchaseService(_unitOfWork);
            Sales = new SalesService(_unitOfWork);
        }



    }
}
