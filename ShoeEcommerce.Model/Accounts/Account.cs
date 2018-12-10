using ShoeEcommerce.Model.Advertisements;
using ShoeEcommerce.Model.Bills;
using ShoeEcommerce.Model.Extensions;
using ShoeEcommerce.Model.Products;
using ShoeEcommerce.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoeEcommerce.Model.Accounts
{
    public class Account
    {
        [Key,StringLength(10)]
        public string idAccount { get; set; }
        [Required,StringLength(30)]
        public string username { get; set; }
        [Required]
        public string passwd { get; set; }
        [Required]                                              
        public string avt_path { get; set; }
        [Required,DefaultValue(value:0)]
        public int rate { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public bool stt { get; set; }

        //ref====
        [Required, StringLength(10)]
        public string rankVip { get; set; }
        [StringLength(10)]
        public string IdMerchant { get; set; }
        public virtual Merchant Merchant { get; set; }
        [StringLength(10)]
        public string idCustomer { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<Advertisement> Advertisements { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<historySearch> HistorySearches { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual RankVip RankVip { get; set; }
        
        

    }
}
