using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models.Accounts
{
    public class Email
    {
        [Key,StringLength(10)]
        public string id { get; set; }
       
        public string email { get; set; }
        //ref===
        [StringLength(10)]
        public string IdAccount { get; set; }
        public virtual Account Account { get; set; }
    }
}
