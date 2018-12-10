using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models.Repositories
{
    public class ImportForm
    {
        [Key,StringLength(10)]
        public string id { get; set; }
        [Required]
        public DateTime creat_date { get; set; }
        [Required,StringLength(10)]
        public string idRepository { get; set; }
        [DefaultValue(value:0)]
        public double total { get; set; }
        //ref===
        public Repository Repository { get; set; }
        public virtual ICollection<ItemIplist> ItemIplists { get; set; }
    }
}
