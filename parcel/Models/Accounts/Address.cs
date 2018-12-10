using EcMnt.Models.Bills;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models.Accounts
{
    public class Address
    {
        [Key]
        public string id { get; set; }
        [Required,StringLength(100)]
        public string add_Info { get; set; }
        [Required, StringLength(20)]
        public string subDistrict { get; set; }
        [Required, StringLength(20)]
        public string District_town { get; set; }
        [Required, StringLength(20)]
        public string City_Provine { get; set; }

        //ref===
        [Required, StringLength(10)]
        public string idAccount { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
