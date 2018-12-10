using EcMnt.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models.Users
{
    public class Customer
    {
        [Key,StringLength(10)]
        public string idCustomer { get; set; }
        [Required,StringLength(50)]
        public string lstname { get; set; }
        [Required,StringLength(50)]
        public string fstname { get; set; }
        [Required]
        public string phone { get; set; }
        //ref===
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Link_ImgStore> Link_ImgStores { get; set; }
    }
}
