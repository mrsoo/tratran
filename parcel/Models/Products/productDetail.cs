using EcMnt.Models.Accounts;
using EcMnt.Models.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models.Products
{
    public class productDetail
    {
        [Key, StringLength(10)]
        public string idproductDetail { get; set; }
        [ForeignKey("Product"), Required, StringLength(10), DisplayName("Id sản phẩm")]
        public string idProduct { get; set; }

        [Required, DefaultValue(value: 0f)]
        public double price { get; set; }

        public DateTime creat_date { get; set; }
        [Required,DefaultValue(value:0)]
        public int count { get; set; }
        [DefaultValue(value:15)]
        public float fee { get; set; }
        //ref===========
        //[ForeignKey("Product"), Required, StringLength(10), DisplayName("Id sản phẩm")]
        //public string idProduct { get; set; }
        [StringLength(10),Required]
        public string IdAcc { get; set; }
        public virtual Account Account { get; set; }
        [StringLength(10)]
        public string IdRepository { get; set; }
        public virtual Repository Repository { get; set; }
        public virtual Product Product { get; set; }    //one to one
        public virtual ICollection<ImageProduct> ImageProducts { get; set; }

    }
}
