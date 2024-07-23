using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace InventoryManagement.DAL.Entities
{
    public class Purchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public DateTime CreatedAt{ get; set; }

        // Navigation properties
        [ValidateNever]
        public Store Store { get; set; }

        [ValidateNever]
        [JsonIgnore]
        public ICollection<PurchaseProduct> PurchaseProducts { get; set; }

    }
}
