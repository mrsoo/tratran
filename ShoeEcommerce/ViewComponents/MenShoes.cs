using Microsoft.AspNetCore.Mvc;
using ShoeEcommerce.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeEcommerce.ViewComponents
{
    public class MenShoes : ViewComponent
    {
        IProductService Service;
        public MenShoes(IProductService service)
        {
            Service = service;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var item = await Service.GetProductBySexManConditionAsync();
            return View(item);
        }
    }
}
