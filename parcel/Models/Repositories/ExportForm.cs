using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models.Repositories
{
    public class ExportForm
    {
        [Key,StringLength(10)]
        public string id { get; set; }
        [Required]
        public DateTime creat_date { get; set; }
        [Required]
        public string idRepository { get; set; }
        public double total { get; set; }
        //ref===
        public virtual Repository Repository { get; set; }
        public virtual ICollection<ItemEplist> ItemExlists { get; set; }
    }
}
