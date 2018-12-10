using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoeEcommerce.Data;
using ShoeEcommerce.Model.Products;

namespace ShoeEcommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ShoeEcommerceDBContext _context;

        public ProductsController(ShoeEcommerceDBContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var shoeEcommerceDBContext = _context.Products.Include(p => p.Account).Include(p => p.Brand).Include(p => p.Category).Include(p => p.Repository);
            return View(await shoeEcommerceDBContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Account)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Repository)
                .FirstOrDefaultAsync(m => m.idProduct == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["idAccount"] = new SelectList(_context.Accounts, "idAccount", "idAccount");
            ViewData["IdBrand"] = new SelectList(_context.Brands, "IdBrand", "IdBrand");
            ViewData["idCategory"] = new SelectList(_context.Categories, "idCategory", "idCategory");
            ViewData["IdRepository"] = new SelectList(_context.Repositories, "idRepository", "idRepository");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idProduct,nameProduct,Code,Description,Image,Size,Sex,OldPrice,Price,Creat_date,Count,Fee,Home,Status,View,Color,idCategory,idAccount,IdRepository,IdBrand")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idAccount"] = new SelectList(_context.Accounts, "idAccount", "idAccount", product.idAccount);
            ViewData["IdBrand"] = new SelectList(_context.Brands, "IdBrand", "IdBrand", product.IdBrand);
            ViewData["idCategory"] = new SelectList(_context.Categories, "idCategory", "idCategory", product.idCategory);
            ViewData["IdRepository"] = new SelectList(_context.Repositories, "idRepository", "idRepository", product.IdRepository);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["idAccount"] = new SelectList(_context.Accounts, "idAccount", "idAccount", product.idAccount);
            ViewData["IdBrand"] = new SelectList(_context.Brands, "IdBrand", "IdBrand", product.IdBrand);
            ViewData["idCategory"] = new SelectList(_context.Categories, "idCategory", "idCategory", product.idCategory);
            ViewData["IdRepository"] = new SelectList(_context.Repositories, "idRepository", "idRepository", product.IdRepository);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("idProduct,nameProduct,Code,Description,Image,Size,Sex,OldPrice,Price,Creat_date,Count,Fee,Home,Status,View,Color,idCategory,idAccount,IdRepository,IdBrand")] Product product)
        {
            if (id != product.idProduct)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.idProduct))
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
            ViewData["idAccount"] = new SelectList(_context.Accounts, "idAccount", "idAccount", product.idAccount);
            ViewData["IdBrand"] = new SelectList(_context.Brands, "IdBrand", "IdBrand", product.IdBrand);
            ViewData["idCategory"] = new SelectList(_context.Categories, "idCategory", "idCategory", product.idCategory);
            ViewData["IdRepository"] = new SelectList(_context.Repositories, "idRepository", "idRepository", product.IdRepository);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Account)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Repository)
                .FirstOrDefaultAsync(m => m.idProduct == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(string id)
        {
            return _context.Products.Any(e => e.idProduct == id);
        }
    }
}
