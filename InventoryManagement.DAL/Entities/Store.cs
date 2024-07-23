using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace InventoryManagement.DAL.Entities
{
    public class Store
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        // Navigation properties
        [ValidateNever]
        [JsonIgnore]
        public ICollection<ApplicationUser> Employees { get; set; }
        [ValidateNever]
        [JsonIgnore]
        public ICollection<Sale> Sales { get; set; }
        [ValidateNever]
        [JsonIgnore]
        public ICollection<Purchase> Purchases { get; set; }
        [ValidateNever]
        [JsonIgnore]
        public ICollection<StoreProduct> StoreProducts { get; set; }
    }
}
