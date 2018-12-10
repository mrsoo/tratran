using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoeEcommerce.Common;
using ShoeEcommerce.Data;
using ShoeEcommerce.Model.Accounts;
using ShoeEcommerce.Model.AdminManager;
using ShoeEcommerce.Service;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ShoeEcommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterNotifiesController : Controller
    {
        private readonly ShoeEcommerceDBContext _context;
        private IRegisterNotifyService registerNotifyService;

        public RegisterNotifiesController(ShoeEcommerceDBContext context, IRegisterNotifyService registerNotifyService)
        {
            _context = context;
            this.registerNotifyService = registerNotifyService;
        }

        // GET: Admin/RegisterNotifies
        public async Task<IActionResult> Index()
        {
            var list = await _context.RegisterNotifies.ToListAsync();
            list.OrderBy(p => p.createdDate);
            return View(list);
        }

        // GET: Admin/RegisterNotifies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerNotify = await _context.RegisterNotifies
                .FirstOrDefaultAsync(m => m.id == id);
            if (registerNotify == null)
            {
                return NotFound();
            }
            _context.Entry(registerNotify).Reference(s => s.Account).Load();
            _context.Entry(registerNotify).Reference(s => s.Merchant).Load();
            var acc = registerNotify.Account;
            var mer = registerNotify.Merchant;
            _context.Entry(acc).Reference(s => s.RankVip).Load();
            _context.Entry(acc).Reference(s => s.Merchant).Load();
            _context.Entry(acc).Collection(s => s.Emails).Load();
            _context.Entry(acc).Collection(s => s.Advertisements).Load();
            _context.Entry(acc).Collection(s => s.Addresses).Load();

            _context.Entry(mer).Collection(s => s.Link_ImgStores).Load();

            TempData["acc"] = acc;
            TempData["mer"] = mer;
            return View(registerNotify);
        }

        // GET: Admin/RegisterNotifies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/RegisterNotifies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,id_Acc,id_Mer,createdDate,Checked,stt")] RegisterNotify registerNotify)
        {
            if (ModelState.IsValid)
            {
                await registerNotifyService.CreateRegisterNotifyAsync(registerNotify);
                return RedirectToAction(nameof(Index));
            }
            return View(registerNotify);
        }

        // GET: Admin/RegisterNotifies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerNotify = await _context.RegisterNotifies.FindAsync(id);
            if (registerNotify == null)
            {
                return NotFound();
            }
            return View(registerNotify);
        }

        // POST: Admin/RegisterNotifies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,id_Acc,id_Mer,createdDate,Checked,stt")] RegisterNotify registerNotify)
        {
            if (id != registerNotify.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registerNotify);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterNotifyExists(registerNotify.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(registerNotify);
        }

        // GET: Admin/RegisterNotifies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerNotify = await _context.RegisterNotifies
                .FirstOrDefaultAsync(m => m.id == id);
            if (registerNotify == null)
            {
                return NotFound();
            }

            return View(registerNotify);
        }

        // POST: Admin/RegisterNotifies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var registerNotify = registerNotifyService.Find(id);
            registerNotify.stt = false;
            await registerNotifyService.UpdateRegisterNotifyAsync(registerNotify);
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterNotifyExists(string id)
        {
            return _context.RegisterNotifies.Any(e => e.id == id);
        }

        private bool CheckCurSession()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("id"))) return false;
            return true;
        }

        public async Task<IActionResult> CheckAsync(string id)
        {
            if (CheckCurSession())
            {
                var tran = _context.Database.BeginTransaction();
                try
                {
                    var Obj = registerNotifyService.Find(id);

                    if (Obj != null)
                    {
                        //load Khóa ngoại
                        _context.Entry(Obj).Reference(s => s.Account).Load();
                        _context.Entry(Obj).Reference(s => s.Merchant).Load();
                        //thông qua thông báo
                        Obj.Checked = true;
                        //thông qua Tài khoản
                        Obj.Account.stt = true;
                        //thông qua thông tin Merchant
                        Obj.Merchant.stt = true;
                        await registerNotifyService.UpdateRegisterNotifyAsync(Obj);
                        //send-email

                        SendEmail(Obj.Account, true);
                    }
                    tran.Commit();
                    tran.Dispose();
                }
                catch (Exception ex)
                {
                    TempData["mes"] = "Duyệt không thành công";
                    tran.Rollback();
                    tran.Dispose();
                }
            }
            else
                TempData["meslogin"] = "Yêu cầu đăng nhập";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AbortRequestAsync(string id)
        {
            if (CheckCurSession())
            {
                var tran = _context.Database.BeginTransaction();
                try
                {
                    var Obj = registerNotifyService.Find(id);

                    if (Obj != null)
                    {
                        //load Khóa ngoại
                        _context.Entry(Obj).Reference(s => s.Account).Load();
                        _context.Entry(Obj).Reference(s => s.Merchant).Load();
                        //thông qua thông báo
                        Obj.Checked = true;
                        //thông qua Tài khoản
                        var acc = Obj.Account;
                        acc.stt = false;
                        _context.Entry(acc).Collection(s => s.Addresses).Load();
                        _context.Entry(acc).Collection(s => s.Emails).Load();
                        //huy email
                        foreach (var item in acc.Emails)
                        {
                            item.stt = false;
                        }
                        //huy address
                        foreach (var item in acc.Addresses)
                        {
                            item.stt = false;
                        }
                        //thông qua thông tin Merchant
                        Obj.Merchant.stt = false;
                        await registerNotifyService.UpdateRegisterNotifyAsync(Obj);
                        SendEmail(Obj.Account, false);
                    }
                    tran.Commit();
                    tran.Dispose();
                }
                catch (Exception ex)
                {
                    TempData["mes"] = "Duyệt không thành công";
                    tran.Rollback();
                    tran.Dispose();
                }
            }
            else
                TempData["meslogin"] = "Yêu cầu đăng nhập";
            return RedirectToAction(nameof(Index));
        }

        private void SendEmail(Account acc, bool v)
        {
            _context.Entry(acc).Collection(s => s.Emails).Load();
            _context.Entry(acc).Reference(s => s.Merchant).Load();
            var account = acc;
            SmtpClient client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(ExtensionTools.emailShop, ExtensionTools.passemailShop)
            };
            if (v)
            {
                // mail to confirm

                foreach (var item in acc.Emails)
                {
                   

                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(ExtensionTools.emailShop);
                    mailMessage.To.Add(item.email);
                    mailMessage.Body = $"Tài khoản {acc.username} đã được kích hoạt cho khách hàng {acc.Merchant.lstname},Trân trọng cảm ơn quí khách đã tin dùng Web Shoes City";
                    mailMessage.Subject = "Thông báo đăng kí từ ShoesCity";
                    client.Send(mailMessage);
                }
            }
            else
            {
                //mail to abort
                foreach (var item in acc.Emails)
                {
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(ExtensionTools.emailShop);
                    mailMessage.To.Add(item.email);
                    mailMessage.Body = $"Tài khoản {acc.username} bị hủy cho khách hàng {acc.Merchant.lstname},Liên hệ với thông tin trên web để biết thêm chi tiết";
                    mailMessage.Subject = "Thông báo đăng kí từ ShoesCity";
                    client.Send(mailMessage);
                }
            }
        }
    }
}