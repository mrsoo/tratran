using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models.Products
{
    public class ImageProduct
    {
        [Key,DisplayName("Mã hình ảnh"),StringLength(10)]
        public string idImage { get; set; }
        [DisplayName("link Hình"),StringLength(40)]
        public string link_Image { get; set; }
        //ref================
        public int idproductDetail { get; set; }
        public productDetail productDetail { get; set; }
    }
}
