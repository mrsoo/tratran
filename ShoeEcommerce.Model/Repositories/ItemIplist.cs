using ShoeEcommerce.Model.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeEcommerce.Model.Repositories
{
    public class ItemIplist
    {
        [Key]
        public int id { get; set; }
        [Required,StringLength(10)]
        public string idProduct { get; set; }
        [Required,StringLength(10)]
        public string idIpForm { get; set; }
        public int count { get; set; }
        //ref===
        public virtual Product Product { get; set; }
        public virtual ImportForm ImportForm { get; set; }
    }
}
