using ShoeEcommerce.Data.Infrastructure;
using ShoeEcommerce.Model.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeEcommerce.Data.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        bool ProductAnyAsyn(string id);
    }
        
    public class ProductRepository : RepositoryBase<Product> , IProductRepository
    {
        public ProductRepository(ShoeEcommerceDBContext ShoeEcommerceDBContext) : base (ShoeEcommerceDBContext)
        {

        }

        public bool ProductAnyAsyn(string id)
        {
            bool item = this.ShoeEcommerceDBContext.Products.Any(e => e.idProduct == id);
            return item;
        }
        
    }
}
