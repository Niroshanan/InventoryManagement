using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.DTOs
{
    public class PurchaseDTO
    {
        public Guid StoreId { get; set; }
        public List<BuyItem> ProductList { get; set; }
    }
}
