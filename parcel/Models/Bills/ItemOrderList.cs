using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models.Bills
{
    public class ItemOrderList
    {
        [Key,StringLength(10)]
        public string idList { get; set; }
        [Required,StringLength(10)]
        public string idProduct { get; set; }
        [Required,StringLength(10)]
        public string idOrder { get; set; }
        [DefaultValue(value:0)]
        public int count { get; set; }
        [Required]
        public int avgRate { get; set; }
        //ref===
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }

    }
}
