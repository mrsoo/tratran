using EcMnt.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models.Extensions
{
    public class historySearch
    {
        [Key]
        public int id { get; set; }
        public string keyword { get; set; }
        [Required,StringLength(10)]
        public string idAcc { get; set; }
        //ref===
        public virtual Account Account  { get; set; }
    }
}
