using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models.OnlinePost
{
    public class Show
    {
        [Key,StringLength(10)]
        public string idShow { get; set; }
        [Required,StringLength(10)]
        public string idPost { get; set; }
        [Required,StringLength(10)]
        public string idProduct { get; set; }
        public string Intro { get; set; }
        //ref====
        public virtual Post Post { get; set; }
        public virtual Product Products { get; set; }

    }
}
