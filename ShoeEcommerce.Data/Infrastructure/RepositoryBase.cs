using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoeEcommerce.Data.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected ShoeEcommerceDBContext ShoeEcommerceDBContext { get; set; }

        public RepositoryBase(ShoeEcommerceDBContext shoeEcommerceDBContext)
        {
            this.ShoeEcommerceDBContext = shoeEcommerceDBContext;
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await this.ShoeEcommerceDBContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByConditionAync(Expression<Func<T, bool>> expression)
        {
            return await this.ShoeEcommerceDBContext.Set<T>().Where(expression).ToListAsync();
        }

        public T Create(T entity)
        {
            var getObject = this.ShoeEcommerceDBContext.Set<T>().Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            this.ShoeEcommerceDBContext.Set<T>().Update(entity);
            return entity;
        }

        public T Delete(T entity)
        {
            this.ShoeEcommerceDBContext.Set<T>().Remove(entity);
            return entity;
        }

        public async Task SaveAsync()
        {
            await this.ShoeEcommerceDBContext.SaveChangesAsync();
        }

        public T Find(string id)
        {
            return ShoeEcommerceDBContext.Set<T>().Find(id);
        }
    }
}
