using EcMnt.Models.Bills;
using EcMnt.Models.OnlinePost;
using EcMnt.Models.Products;
using EcMnt.Models.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models
{
    public class Product
    {
        [Key,StringLength(10),DisplayName("Id sản phẩm")]
        public string idProduct { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string nameProduct { get; set; }
        [StringLength(100),DisplayName("Code")]
        public string code { get; set; }
        [StringLength(100),DisplayName("Mô tả")]
        public string description { get; set; }
        [StringLength(20),DisplayName("Nhãn hiệu")]
        public string brand { get; set; }
        //ref=======================
        //ref tới odder
        [Required]
        public string idCategory { get; set; }
        public virtual Category Category { get; set; }
        public virtual productDetail ProductDetail { get; set; }
        public virtual ICollection<Show> Shows { get; set; }
        public virtual ICollection<ItemIplist> ItemIpLists { get; set; }
        public virtual ICollection<ItemEplist> ItemEpLists { get; set; }
        public virtual ICollection<ItemOrderList> ItemOrderLists { get; set; }
    }
}
