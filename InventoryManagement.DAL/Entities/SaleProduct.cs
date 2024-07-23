using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Entities
{
    public class SaleProduct
    {
        public Guid SaleId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public Sale Sale { get; set; }
        public Product Product { get; set; }
    }
}
