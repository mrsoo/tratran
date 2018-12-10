using Microsoft.AspNetCore.Mvc;
using ShoeEcommerce.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeEcommerce.ViewComponents
{
    public class Category : ViewComponent
    {
        ICategoryService Service;
        public Category(ICategoryService service)
        {
            this.Service = service;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var item = await Service.GetCategoryBySexMansAsync();
            return View(item);
        }
    }
}
