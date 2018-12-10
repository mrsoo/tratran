using Microsoft.AspNetCore.Mvc;
using ShoeEcommerce.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeEcommerce.ViewComponents
{
    public class FeatureProduct : ViewComponent
    {
        ICategoryService Service;
        IProductService ProService;
        public FeatureProduct(ICategoryService service, IProductService prS)
        {
            this.Service = service;
            this.ProService = prS;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mostPopular = await Service.GetAllCategorysAsync();
            ViewBag.item = await ProService.GetProductBySaleConditionAsync();
            return View(mostPopular);
        }
    }
}
