using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models.Repositories
{
    public class ItemEplist
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int idProduct { get; set; }
        [Required]
        public int idEpform { get; set; }
        [DefaultValue(value:0)]
        public int count { get; set; }
        //ref===
        public virtual Product Product { get; set; }
        public virtual ExportForm ExportForm { get; set; }

    }
}
