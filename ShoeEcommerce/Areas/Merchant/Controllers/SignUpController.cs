using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoeEcommerce.Model.ViewModel.Login;
using ShoeEcommerce.Service;

namespace ShoeEcommerce.Areas.Merchant.Controllers
{
    [Area("Merchant")]
    public class SignUpController : Controller
    {
        public SignUpController(IAccountService service, IMerchantService merService)
        {
            this.service = service;
            this.merService = merService;
        }

        private IAccountService service;
        private IMerchantService merService;
        public IActionResult Index()
        {
            return RedirectToAction(nameof(SignUp));
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp([Bind("username,password,avt_path,lstname,fstname,storename,phone,website,add_Info,subDistrict,District_town,City_Provine,email")] RegisterMerchantModelView model)
        {
            if (await merService.SignUpAsync(model))
            {
                TempData["mes"] = $"Đăng kí tài khoản {model.username} thàng công chờ kiểm duyệt";
            }
            else TempData["mes"] = "Đăng kí thất bại, yêu cầu sử dụng thông tin chính xác";
            return View(model);
        }
    }
}