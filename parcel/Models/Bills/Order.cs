using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models.Bills
{
    public class Order
    {
        [Key,StringLength(10)]
        public string idOrder { get; set; }
        public DateTime creat_date { get; set; }
        [DefaultValue(value:0)]
        public int idStt { get; set; }
        [DefaultValue(value: 0)]
        public double total { get; set; }
        //ref====
        [Required,StringLength(10)]
        public string IdSaleAcc { get; set; }
        [Required,StringLength(10)]
        public string idBuyAcc { get; set; }
        public virtual BillState BillState { get; set; }
    }
}
