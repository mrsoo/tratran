using EcMnt.Models.Advertisements;
using EcMnt.Models.Bills;
using EcMnt.Models.Extensions;
using EcMnt.Models.Products;
using EcMnt.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models.Accounts
{
    public class Account
    {
        [Key,StringLength(10)]
        public string idAccount { get; set; }
        [Required,StringLength(30)]
        public string username { get; set; }
        [Required,StringLength(30)]
        public string passwd { get; set; }
        [Required]
        public string avt_path { get; set; }
        [Required,DefaultValue(value:0)]
        public int rate { get; set; }
        [Required,DefaultValue(value:0)]
        public int rankVip { get; set; }
        //ref====
        [Required,StringLength(10)]
        public string IdMerchant { get; set; }
        public virtual Merchant Merchant { get; set; }
        [Required,StringLength(10)]
        public string idCustomer { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<Advertisement> Advertisements { get; set; }
        public virtual ICollection<productDetail> ProductDetails { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<historySearch> HistorySearches { get; set; }

    }
}
