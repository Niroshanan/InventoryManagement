using InventoryManagement.BLL.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.DTOs
{
    public class RegisterModal
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid StoreId { get; set; }
        public String Role { get; set; }
    }
}
