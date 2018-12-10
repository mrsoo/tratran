using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models.Bills
{
    public class BillState
    {
        [Key]
        public int idState { get; set; }
        [StringLength(100),Required]
        public string Description { get; set; }
        //ref====
        public virtual ICollection<Order> Orders { get; set; }
    }
}
