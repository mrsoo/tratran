using Microsoft.AspNetCore.Mvc;
using ShoeEcommerce.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeEcommerce.ViewComponents
{
    public class ProductDetail : ViewComponent
    {
        IProductService Service;
        public ProductDetail(IProductService Service)
        {
            this.Service = Service;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var item = await Service.GetProductByIdAsync(id);
            return View(item);
        }
    }
}
