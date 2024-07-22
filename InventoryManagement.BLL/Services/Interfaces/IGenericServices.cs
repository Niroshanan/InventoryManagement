using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Services.Interfaces
{
    public interface IGenericServices
    {
        IProductService Products { get; }
        IPurchaseService Purchase { get; }
        ISalesService Sales { get; }

    }
}
