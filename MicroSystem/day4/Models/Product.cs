using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicroShopping.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Product Name Required")]
        [MaxLength(50)]
        [MinLength(3, ErrorMessage = "minimum 3 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product Quantity Required")]
        [Range(typeof(int), "1", "100", ErrorMessage = "Invalid Quantity")]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "money")]
       [Range(1, 5000, ErrorMessage = "Invalid Price")]
        public Decimal Price { get; set; }

        [Required(ErrorMessage = "Product Description Required")]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Product Image Required")]
        [MaxLength(500)]
        public string Image { get; set; }
    }
}
