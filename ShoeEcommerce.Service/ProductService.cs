using ShoeEcommerce.Data.Repository;
using ShoeEcommerce.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeEcommerce.Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(string id);
        //Task<ProductExtended> GetProductWithDetailsAsync(Guid ProductId);
        Task<IEnumerable<Product>> GetProductByHomeConditionAsync();

        Task<IEnumerable<Product>> GetProductBySaleConditionAsync();

        Task<IEnumerable<Product>> GetProductBySexManConditionAsync();
        Task<IEnumerable<Product>> GetProductBySexWomanConditionAsync();

        Task CreateProductAsync(Product item);
        Task UpdateProductAsync(Product item);
        Task DeleteProductAsync(Product item);
        bool ProducAnyAsync(string id);
    }

    public class ProductService : IProductService
    {
        IProductRepository Repositoty;
        public ProductService(IProductRepository repository)
        {
            this.Repositoty = repository;
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var item = await Repositoty.FindAllAsync();
            return item.OrderBy(x => x.nameProduct);
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            var item = await Repositoty.FindByConditionAync(o => o.idProduct.Equals(id));
            return item.DefaultIfEmpty(new Product())
                    .FirstOrDefault();
        }
        public async Task<IEnumerable<Product>>GetProductByHomeConditionAsync()
        {
            var item = await Repositoty.FindByConditionAync(o => o.Home.Equals(true));
            return item;
        }
        public async Task<IEnumerable<Product>> GetProductBySaleConditionAsync()
        {
            var item = await Repositoty.FindByConditionAync(l => l.OldPrice != 0 && l.Home.Equals(true) && l.Status.Equals(true));
            return item;
        }
        public async Task<IEnumerable<Product>> GetProductBySexManConditionAsync()
        {
            var item = await Repositoty.FindByConditionAync(l => l.Sex.Equals(true) && l.Home.Equals(true) && l.Status.Equals(true));
            return item;
        }
        public async Task<IEnumerable<Product>> GetProductBySexWomanConditionAsync()
        {
            var item = await Repositoty.FindByConditionAync(l => l.Sex.Equals(false) && l.Home.Equals(true) && l.Status.Equals(true));
            return item;
        }
        public async Task CreateProductAsync(Product item)
        {
            Repositoty.Create(item);
            await Repositoty.SaveAsync();
        }

        public async Task UpdateProductAsync(Product item)
        {
            Repositoty.Update(item);
            await Repositoty.SaveAsync();
        }

        public async Task DeleteProductAsync(Product item)
        {
            Repositoty.Delete(item);
            await Repositoty.SaveAsync();
        }
        public bool ProducAnyAsync(string id)
        {
            var check = Repositoty.ProductAnyAsyn(id);
            return check;
        }

        
    }
}
