﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicroShopping.Models
{
    public class Reviews_Ratings
    {
        public int ID { get; set; }
        [Required]
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public Product Product { get; set; }
        [ForeignKey("User")]
        public String UserID { get; set; }
        public IdentityUser User { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
        public int Rate { get; set; }
        public string Review { get; set; }
    }
}
