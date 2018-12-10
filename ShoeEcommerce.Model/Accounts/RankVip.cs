using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeEcommerce.Model.Accounts
{
    public class RankVip
    {
        [Key,StringLength(10)]
        public string idRank { get; set; }
        [DefaultValue(value:0)]
        public int viewRate { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public bool stt { get; set; }

    }
}
