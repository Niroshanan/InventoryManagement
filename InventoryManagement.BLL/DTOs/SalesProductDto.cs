using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.DTOs
{
    public class SalesProductDto
    {
        public string ProductName { get; set; }
        public string StoreName { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
