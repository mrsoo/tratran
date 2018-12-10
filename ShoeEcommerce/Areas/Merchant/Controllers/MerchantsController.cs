using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoeEcommerce.Data;
using ShoeEcommerce.Model.Users;
using ShoeEcommerce.Service;

namespace ShoeEcommerce.Areas.Merchant.Controllers
{
    [Area("Merchant")]
    public class MerchantsController : Controller
    {
        private readonly ShoeEcommerceDBContext _context;

        private IMerchantService merchantService;

        public MerchantsController(ShoeEcommerceDBContext context, IMerchantService merchantService)
        {
            _context = context;
            this.merchantService = merchantService;
        }

        // GET: Merchant/Merchants
        public async Task<IActionResult> Index()
        {
            var list = await merchantService.GetAllMerchantsAsync();
            
            return View(list.Where(p => p.stt == true).OrderBy(p => p.idMerchant));
        }

        // GET: Merchant/Merchants/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchant = await _context.Merchants
                .FirstOrDefaultAsync(m => m.idMerchant == id);
            if (merchant == null)
            {
                return NotFound();
            }

            return View(merchant);
        }

        // GET: Merchant/Merchants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Merchant/Merchants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idMerchant,lstname,fstname,storename,phone,website,stt")] Model.Users.Merchant merchant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(merchant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(merchant);
        }

        // GET: Merchant/Merchants/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchant = await _context.Merchants.FindAsync(id);
            if (merchant == null)
            {
                return NotFound();
            }
            return View(merchant);
        }

        // POST: Merchant/Merchants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("idMerchant,lstname,fstname,storename,phone,website,stt")] Model.Users.Merchant merchant)
        {
            if (id != merchant.idMerchant)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merchant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MerchantExists(merchant.idMerchant))
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
            return View(merchant);
        }

        // GET: Merchant/Merchants/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchant = await _context.Merchants
                .FirstOrDefaultAsync(m => m.idMerchant == id);
            if (merchant == null)
            {
                return NotFound();
            }

            return View(merchant);
        }

        // POST: Merchant/Merchants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var merchant = await _context.Merchants.FindAsync(id);
            _context.Merchants.Remove(merchant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MerchantExists(string id)
        {
            return _context.Merchants.Any(e => e.idMerchant == id);
        }
       
    }
}
