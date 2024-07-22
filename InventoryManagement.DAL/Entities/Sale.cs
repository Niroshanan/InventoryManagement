using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace InventoryManagement.DAL.Entities
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }

        public DateTime CreatedAt{ get; set; }

        // Navigation properties
        public Store Store { get; set; }

        [ValidateNever]
        [JsonIgnore]
        public ICollection<SaleProduct> SaleProducts { get; set; }
    }
}
