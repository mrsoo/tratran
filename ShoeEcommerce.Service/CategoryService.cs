using ShoeEcommerce.Data.Repository;
using ShoeEcommerce.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeEcommerce.Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategorysAsync();
        Task<Category> GetCategoryByIdAsync(string id);
        //Task<CategoryExtended> GetCategoryWithDetailsAsync(Guid CategoryId);
        Task<IEnumerable<Category>> GetCategoryBySexMansAsync();
        Task<IEnumerable<Category>> GetCategoryBySexWomansAsync();
        Task CreateCategoryAsync(Category item);
        Task UpdateCategoryAsync(Category item);
        Task DeleteCategoryAsync(Category item);
    }

    public class CategoryService : ICategoryService
    {
        ICategoryRepository Repositoty;
        public CategoryService(ICategoryRepository repository)
        {
            this.Repositoty = repository;
        }
        public async Task<IEnumerable<Category>> GetAllCategorysAsync()
        {
            var item = await Repositoty.FindAllAsync();
            return item.OrderBy(x => x.nameCategory);
        }

        public async Task<Category> GetCategoryByIdAsync(string id)
        {
            var item = await Repositoty.FindByConditionAync(o => o.idCategory.Equals(id));
            return item.DefaultIfEmpty(new Category())
                    .FirstOrDefault();
        }
        public async Task<IEnumerable<Category>> GetCategoryBySexMansAsync()
        {
            var item = await Repositoty.FindByConditionAync(l=>l.Sex.Equals(true));
            return item;
        }

        public async Task<IEnumerable<Category>> GetCategoryBySexWomansAsync()
        {
            var item = await Repositoty.FindByConditionAync(l => l.Sex.Equals(false));
            return item;
        }
        public async Task CreateCategoryAsync(Category item)
        {
            Repositoty.Create(item);
            await Repositoty.SaveAsync();
        }

        public async Task UpdateCategoryAsync(Category item)
        {
            Repositoty.Update(item);
            await Repositoty.SaveAsync();
        }

        public async Task DeleteCategoryAsync(Category item)
        {
            Repositoty.Delete(item);
            await Repositoty.SaveAsync();
        }

        
    }
}
