using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeEcommerce.Model.ViewModel.Login;
using ShoeEcommerce.Service;

namespace ShoeEcommerce.Controllers
{
    public class ToolController : Controller
    {
        private IAccountService service;

        public ToolController(IAccountService service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("username,password,remember")] LoginViewModel loginModel)
        {
            if(!string.IsNullOrEmpty(loginModel.username) && !string.IsNullOrEmpty(loginModel.password)){
                var rs = service.isAuthenticated(loginModel.username, loginModel.password);
                if (rs != null)
                {
                    HttpContext.Session.SetString("username", rs.username);
                    HttpContext.Session.SetString("id", rs.idAccount);

                    if (rs.idAccount.Contains("root")) return Redirect(@"~/adminhome");
                    if (rs.idCustomer.Equals("noone")) return Redirect(@"~/merchanthome");
                    return Redirect(@"~/");
                }
                else ViewBag.message = "Sai mật khẩu hoặc tài khoản";
            }else
            ViewBag.message = "Nhập mật khẩu hoặc tài khoản";
            return View(loginModel);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("id");
            return Redirect("~/");
        }

        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup([Bind("username,password,avt_path,lstname,fstname,phone,add_Info,subDistrict,District_town,City_Provine,email")] RegisterModelView registerModelView)
        {

            if (await service.RegisterAsync(registerModelView))
            {
                TempData["mes"] = $"Đăng ký Tài khoản {registerModelView.username} thành công";
            }
            else
                TempData["mes"] = "Đăng ký không thành công";
            return View(registerModelView);
        }
    }
}