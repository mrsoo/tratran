using ShoeEcommerce.Model.Accounts;
using ShoeEcommerce.Model.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoeEcommerce.Model.AdminManager
{
    public class RegisterNotify
    {
        [Key]
        public string id { get; set; }

        public DateTime createdDate { get; set; }
        public bool Checked { get; set; }
        public bool stt { get; set; }

        //ref==
        public string id_Acc { get; set; }

        [ForeignKey("id_Acc")]
        public virtual Account Account { get; set; }

        public string id_Mer { get; set; }
        [ForeignKey("id_Mer")]
        public virtual Merchant Merchant { get; set; }
    }
}
