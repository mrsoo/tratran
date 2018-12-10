using ShoeEcommerce.Model.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeEcommerce.Model.Users
{
    public class Customer
    {
        [Key,StringLength(10),DisplayName("id khách hàng")]
        public string idCustomer { get; set; }
        [Required,StringLength(50),DisplayName("Tên")]
        public string lstname { get; set; }
        [Required,StringLength(50),DisplayName("Họ")]
        public string fstname { get; set; }
        [Required,DisplayName("Số điện thoại")]
        public string phone { get; set; }
        [DisplayName("Trạng thái")]
        public bool stt { get; set; }
        //ref===
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
