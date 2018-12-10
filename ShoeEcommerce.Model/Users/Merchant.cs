using ShoeEcommerce.Model.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeEcommerce.Model.Users
{
    public class Merchant
    {
        [Key,StringLength(10),DisplayName("id khách hàng (M)")]
        public string idMerchant { get; set; }
        [Required,StringLength(20),DisplayName("Tên")]
        public string lstname { get; set; }
        [Required,StringLength(20),DisplayName("Họ")]
        public string fstname { get; set; }
        [Required,StringLength(60),DisplayName("Tên cửa hàng")]
        public string storename { get; set; }
        [Phone,Required,DisplayName("Số điện thoại")]
        public string phone { get; set; }
        [DisplayName("Trang web")]
        public string website { get; set; }
        [DisplayName("Trạng thái")]
        public bool stt { get; set; }

        //ref===
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Link_ImgStore> Link_ImgStores { get; set; }

    }
}
