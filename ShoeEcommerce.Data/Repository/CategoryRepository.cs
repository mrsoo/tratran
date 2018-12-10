using ShoeEcommerce.Data.Infrastructure;
using ShoeEcommerce.Model.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoeEcommerce.Data.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {

    }
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ShoeEcommerceDBContext ShoeEcommerceDBContext) : base(ShoeEcommerceDBContext)
        {
        }

       


    }
}
