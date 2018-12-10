using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models.Bills
{
    public class Rating
    {
        [Key]
        public int id { get; set; }
        
        [Required]
        public int rateValue { get; set; }
        [Required]
        public string Cmt { get; set; }
        //ref===
        [Required]
        public int idItemOrderList { get; set; }
        public virtual ItemOrderList ItemOrderList { get; set; }
    }
}
