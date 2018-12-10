using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeEcommerce.Model.Accounts;
using ShoeEcommerce.Service;

namespace ShoeEcommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DefaultController : Controller
    {
        private IRegisterNotifyService registerNotifyService;
        private IAccountService accservice;

        public DefaultController(IRegisterNotifyService registerNotifyService,IAccountService accountService)
        {
            this.registerNotifyService = registerNotifyService;
            this.accservice = accountService;
        }

        [Route("adminhome")]
        public async Task<IActionResult> Index()
        {
            var cur = await accservice.GetAccountByIdAsync(HttpContext.Session.GetString("id"));
            if (!cur.stt) TempData["mes"] = "Vui lòng cấp quyền Admin cho tài khoản";
            Account curacc =  await accservice.GetAccountByIdAsync(HttpContext.Session.GetString("id"));

                var list = await registerNotifyService.GetUncheckedNoticeAsync();
            ViewData["numNotice"] = list.Count();

            ViewData["curStt"] = (curacc.stt);// ? "TK đang hoạt động" : "TK đã bị khóa";
            return View(curacc);
        }

        private async Task SetInFoAsync()
        {
            var  list = await registerNotifyService.GetAllRegisterNotifyAsync();
        }
    }
}