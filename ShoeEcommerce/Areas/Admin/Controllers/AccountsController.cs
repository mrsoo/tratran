using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoeEcommerce.Data;
using ShoeEcommerce.Model.Accounts;

namespace ShoeEcommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountsController : Controller
    {
        private readonly ShoeEcommerceDBContext _context;

        public AccountsController(ShoeEcommerceDBContext context)
        {
            _context = context;
        }

        // GET: Admin/Accounts
        public async Task<IActionResult> Index()
        {
            var shoeEcommerceDBContext = _context.Accounts.Include(a => a.Customer).Include(a => a.Merchant);
            return View(await shoeEcommerceDBContext.ToListAsync());
        }

        // GET: Admin/Accounts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Customer)
                .Include(a => a.Merchant)
                .FirstOrDefaultAsync(m => m.idAccount == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Admin/Accounts/Create
        public IActionResult Create()
        {
            ViewData["idCustomer"] = new SelectList(_context.Customers, "idCustomer", "idCustomer");
            ViewData["IdMerchant"] = new SelectList(_context.Merchants, "idMerchant", "idMerchant");
            return View();
        }

        // POST: Admin/Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idAccount,username,passwd,avt_path,rate,rankVip,IdMerchant,idCustomer")] Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["idCustomer"] = new SelectList(_context.Customers, "idCustomer", "idCustomer", account.idCustomer);
            //ViewData["IdMerchant"] = new SelectList(_context.Merchants, "idMerchant", "idMerchant", account.IdMerchant);
            return View(account);
        }

        // GET: Admin/Accounts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            ViewData["idCustomer"] = new SelectList(_context.Customers, "idCustomer", "idCustomer", account.idCustomer);
            ViewData["IdMerchant"] = new SelectList(_context.Merchants, "idMerchant", "idMerchant", account.IdMerchant);
            return View(account);
        }

        // POST: Admin/Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("idAccount,username,passwd,avt_path,rate,rankVip,IdMerchant,idCustomer")] Account account)
        {
            if (id != account.idAccount)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.idAccount))
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
            ViewData["idCustomer"] = new SelectList(_context.Customers, "idCustomer", "idCustomer", account.idCustomer);
            ViewData["IdMerchant"] = new SelectList(_context.Merchants, "idMerchant", "idMerchant", account.IdMerchant);
            return View(account);
        }

        // GET: Admin/Accounts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Customer)
                .Include(a => a.Merchant)
                .FirstOrDefaultAsync(m => m.idAccount == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Admin/Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var account = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(string id)
        {
            return _context.Accounts.Any(e => e.idAccount == id);
        }
    }
}
