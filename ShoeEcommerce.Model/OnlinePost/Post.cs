using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeEcommerce.Model.OnlinePost
{
    public class Post
    {
        [Key,StringLength(10),DisplayName("Mã bài Post")]
        public string idPost { get; set; }
        [Required]
        public string idAcc { get; set; }//merchant acc
        public DateTime create_date { get; set; }
        [DefaultValue(value:0)]
        public int curRank { get; set; }
        //ref===
        public virtual ICollection<Show> Shows { get; set; }

    }
}
