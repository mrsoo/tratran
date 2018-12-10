using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoeEcommerce.Model.ViewModel.Login
{
    public class RegisterModelView
    {
        public string username { get; set; }
        public string password { get; set; }
        public string avt_path { get; set; }

        //customer
        public string lstname { get; set; }
        public string fstname { get; set; }
        [Phone]
        public string phone { get; set; }
        public string add_Info { get; set; }
        public string subDistrict { get; set; }
        public string District_town { get; set; }
        public string City_Provine { get; set; }
        public string email { get; set; }
    }
}
