using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeEcommerce.Model.Products
{
    public class Category
    {
        [Key,StringLength(10),DisplayName("id Loại")]
        public string idCategory { get; set; }
        [DisplayName("Tên loại"),Required]
        public string nameCategory { get; set; }
        [DisplayName("Hình đại diện cho category")]
        public string link_imageCategory { get; set; }

        [DisplayName("Giới tính")]
        public bool Sex { get; set; }
        //ref====================
        public ICollection<Product> Products { get; set; }

    }
}
