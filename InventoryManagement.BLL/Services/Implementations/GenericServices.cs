using AutoMapper;
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
        private readonly IMapper _mapper;
        public IProductService Products { get; private set; }
        public IPurchaseService Purchase { get; private set; }
        public ISalesService Sales { get; private set; }
        public ICategoryService Categories { get; private set; }
        public IStoreService Stores { get; private set; }

        public GenericServices(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            Products = new ProductService(_unitOfWork , _mapper);
            Purchase = new PurchaseService(_unitOfWork);
            Sales = new SalesService(_unitOfWork, _mapper);
            Stores = new StoreService(_unitOfWork, _mapper);
            Categories = new CategoryService(_unitOfWork ,_mapper);
        }



    }
}
