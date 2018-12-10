using ShoeEcommerce.Model.Accounts;
using ShoeEcommerce.Model.Bills;
using ShoeEcommerce.Model.OnlinePost;
using ShoeEcommerce.Model.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoeEcommerce.Model.Products
{
    public class Product
    {
        [Key,StringLength(10),DisplayName("Id sản phẩm")]
        public string idProduct { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string nameProduct { get; set; }

        [StringLength(100),DisplayName("Code")]
        public string Code { get; set; }

        [StringLength(100),DisplayName("Mô tả")]
        public string Description { get; set; }

        [StringLength(500), DisplayName("Hình ảnh")]
        public string Image { get; set; }

        [DisplayName("Kích thước")]
        public int Size { get; set; }

        [DisplayName("Giới tính")]
        public bool Sex { get; set; }

        [DefaultValue(value: 0f), DisplayName("Giá cũ")]
        public double OldPrice { get; set; }

        [Required, DefaultValue(value: 0f), DisplayName("Giá")]
        public double Price { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime Creat_date { get; set; }

        [Required, DefaultValue(value: 0)]
        [DisplayName("Số lượng")]
        public int Count { get; set; }

        [DefaultValue(value: 15),DisplayName("Huê hồng")]
        public float Fee { get; set; }

        [DisplayName("Hiển thị trang chủ")]
        public bool Home { get; set; }

        [DisplayName("Trạng thái")]
        public bool Status { get; set; }

        [DisplayName("Lượt xem")]
        public int View { get; set; }

        [StringLength(100),DisplayName("Màu sắc")]
        public string Color { get; set; }


        //ref=======================
        //ref tới odder
        [StringLength(10), Required]
        public string idCategory { get; set; }
        public virtual Category Category { get; set; }

        [StringLength(10), Required]
        public string idAccount { get; set; }
        public virtual Account Account { get; set; }

        [StringLength(10)]
        public string IdRepository { get; set; }
        public virtual Repository Repository { get; set; }

        public int IdBrand { get; set; }
        public virtual Brand Brand { get; set; }

        public virtual ICollection<ImageProduct> ImageProducts { get; set; }
        public virtual ICollection<Show> Shows { get; set; }
        public virtual ICollection<ItemIplist> ItemIpLists { get; set; }
        public virtual ICollection<ItemEplist> ItemEpLists { get; set; }
        public virtual ICollection<ItemOrderList> ItemOrderLists { get; set; }
    }
}
