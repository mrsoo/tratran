using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeEcommerce.Model.Accounts;
using ShoeEcommerce.Service;

namespace ShoeEcommerce.Areas.Merchant.Controllers
{
    [Area("Merchant")]
    public class DefaultController : Controller
    {
        private IAccountService accservice;

        public DefaultController(IAccountService accservice)
        {
            this.accservice = accservice;
        }

        [Route("merchanthome")]
        public async Task<IActionResult> Index()
        {
            var cur = await accservice.GetAccountByIdAsync(HttpContext.Session.GetString("id"));
            if (!cur.stt) TempData["mes"] = "Vui lòng cấp quyền Merchant cho tài khoản";
            Account curacc = await accservice.GetAccountByIdAsync(HttpContext.Session.GetString("id"));
            ViewData["curStt"] = (curacc.stt);// ? "TK đang hoạt động" : "TK đã bị khóa";
            return View(curacc);
        }
    }
}