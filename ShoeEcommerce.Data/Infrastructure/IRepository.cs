using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoeEcommerce.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> FindAllAsync();
        Task<IEnumerable<T>> FindByConditionAync(Expression<Func<T, bool>> expression);
        T Find(string id);
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
        Task SaveAsync();
    }
}
