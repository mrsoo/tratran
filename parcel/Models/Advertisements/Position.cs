using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models.Advertisements
{
    public class Position
    {
        [Key]
        public int idPosition { get; set; }
        [Required]
        public float width { get; set; }
        [Required]
        public float height { get; set; }
    }
}
