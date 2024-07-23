using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public  Category Category { get; set; }

        [ValidateNever]
        [JsonIgnore]
        public ICollection<StoreProduct> StoreProducts { get; set; }

        [ValidateNever]
        [JsonIgnore]
        public ICollection<SaleProduct> SaleProducts { get; set; }

        [ValidateNever]
        [JsonIgnore]
        public ICollection<PurchaseProduct> PurchaseProducts { get; set; }

    }
}
