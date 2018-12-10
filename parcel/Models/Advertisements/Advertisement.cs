using EcMnt.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models.Advertisements
{
    public class Advertisement
    {
        [Key,StringLength(10)]
        public string idAdvertisement { get; set; }
        public DateTime creat_date { get; set; }
        [DefaultValue(value:1)]
        public int expire { get; set; }
        //ref====
        [Required,StringLength(10)]
        public string idAccount { get; set; }
        public Account Account { get; set; }
        [Required]
        public int position { get; set; }
        public virtual Position Position  { get; set; }
    }
}
