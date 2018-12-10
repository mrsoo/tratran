﻿using ShoeEcommerce.Model.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeEcommerce.Model.Repositories
{
    public class Repository
    {
        [Key,StringLength(10)]
        public string idRepository { get; set; }
        [Required]
        public string name { get; set; }
        [Required,StringLength(500)]
        public string Address { get; set; }
        [Required, Range(0, 100, ErrorMessage = "Repos is full")]
        public int Stt { get; set; }
        //ref===
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<ImportForm> ImportForms { get; set; }
    }
}
