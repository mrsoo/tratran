using EcMnt.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models.Users
{
    public class Merchant
    {
        [Key,StringLength(10)]
        public string idMerchant { get; set; }
        [Required,StringLength(20)]
        public string lstname { get; set; }
        [Required,StringLength(20)]
        public string fstname { get; set; }
        [Required,StringLength(60)]
        public string storename { get; set; }
        [Phone,Required]
        public string phone { get; set; }
        public string website { get; set; }
        //ref===
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
