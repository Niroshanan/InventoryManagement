using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public Guid? StoreId { get; set; }
        public Store Store { get; set; }
    }
}
