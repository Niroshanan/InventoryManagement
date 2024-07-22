using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Entities
{
    public class PurchaseProduct
    {
        public Guid PurchaseId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        
        public int BuyingPrice { get; set; }

        // Navigation properties
        public Purchase Purchase { get; set; }
        public Product Product { get; set; }
    }
}
