using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public Guid StoreId{ get; set; }
    }
}
