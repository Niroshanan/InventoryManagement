using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.DTOs
{
    public class BuyItem
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public int BuyingPrice { get; set; }
    }
}
