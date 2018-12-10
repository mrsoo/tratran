using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoeEcommerce.Model.Products
{
    public class Brand
    {
        [Key, DisplayName("Mã nhãn hiệu")]
        public int IdBrand { get; set; }
        [StringLength(200),DisplayName("Tên nhãn hiệu")]
        public string NameBrand { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
