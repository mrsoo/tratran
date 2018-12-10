using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models.Users
{
    public class Link_ImgStore
    {
        [Key,StringLength(10)]
        public string id { get; set; }
        [Required]
        public string path { get; set; }
        //ref===
        public string idMerchant { get; set; }
        public virtual Merchant Merchant { get; set; }
    }
}
