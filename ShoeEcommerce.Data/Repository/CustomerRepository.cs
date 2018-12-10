using ShoeEcommerce.Data.Infrastructure;
using ShoeEcommerce.Model.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeEcommerce.Data.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<string> GetNextId();
    }
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(ShoeEcommerceDBContext ShoeEcommerceDBContext) : base(ShoeEcommerceDBContext)
        {

        }

        public async Task<string> GetNextId()
        {
            var listcus = (await this.FindAllAsync()).Select(p => p.idCustomer);
            int i = 1;
            var date = DateTime.Now;
            string newid = $"{date.Month}{date.Year.ToString().Substring(2)}_{i}";
            while (listcus.Where(p => p.Equals(newid)).Count() > 0)
            {
                i++;
                newid = $"{date.Month}{date.Year.ToString().Substring(2)}_{i}";
            }
            return newid;
        }
    }
    //public class CustomerRepository : RepositoryBase<Customers>,ICustomerRepository
    //{
    //    public CustomerRepository(ShoeEcommerceDBContext ct) : base(ct)
    //    {

    //    }
    //}
}
