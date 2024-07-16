using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Entities
{
    public class StoreProduct
    {
        public Guid StoreId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public Store Store { get; set; }
        public Product Product { get; set; }
    }
}
