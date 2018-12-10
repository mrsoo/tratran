using Microsoft.AspNetCore.Mvc;
using ShoeEcommerce.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeEcommerce.ViewComponents
{
    public class SaleProduct : ViewComponent
    {
        IProductService Service;
        
        public SaleProduct(IProductService service)
        {
            this.Service = service;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var item = await Service.GetProductBySaleConditionAsync();
            return View(item);
        }
    }
}
