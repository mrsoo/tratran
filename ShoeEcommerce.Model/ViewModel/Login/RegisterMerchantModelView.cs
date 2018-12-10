using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoeEcommerce.Model.ViewModel.Login
{
    public class RegisterMerchantModelView
    {
        public string username { get; set; }
        public string password { get; set; }
        public string avt_path { get; set; }

        //merchant
        public string lstname { get; set; }
        public string fstname { get; set; }
        public string storename { get; set; }
        [Phone]
        public string phone { get; set; }
        public string website { get; set; }
        public bool stt { get; set; }
       

        //address
        public string add_Info { get; set; }
        public string subDistrict { get; set; }
        public string District_town { get; set; }
        public string City_Provine { get; set; }
        //email
        public string email { get; set; }
    }
}
