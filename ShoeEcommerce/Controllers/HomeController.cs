using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoeEcommerce.Service;

namespace ShoeEcommerce.Controllers
{
    
    public class HomeController : Controller
    {
        IProductService Service;
        public HomeController(IProductService service)
        {
            Service = service;
        }
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        public async Task <IActionResult> Detail(string id)
        {
            var item = await Service.GetProductByIdAsync(id);
            ViewBag.id = item.idAccount;
            return View();
        }
        public IActionResult FeatureProduct()
        {
            var item = Service.GetAllProductsAsync();
            return PartialView("~/Views/Share/_FeatureProduct.cshtml", item);
        }

        public IActionResult SPNB()
        {

            return View();
        }
    }
}