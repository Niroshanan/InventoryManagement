using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.DTOs
{
    public class SaleDTO
    {
        public Guid StoreId { get; set; }
        public List<SaleItem> ProductList { get; set; }
    }
}
