using ShoeEcommerce.Data.Repository;
using ShoeEcommerce.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeEcommerce.Service
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(string id);
        //Task<CustomerExtended> GetCustomerWithDetailsAsync(Guid CustomerId);
        Task CreateCustomerAsync(Customer item);
        Task UpdateCustomerAsync(Customer item);
        Task DeleteCustomerAsync(Customer item);
    }

    public class CustomerService : ICustomerService
    {
        ICustomerRepository Repositoty;
        public CustomerService(ICustomerRepository repository)
        {
            this.Repositoty = repository;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var item = await Repositoty.FindAllAsync();
            return item.OrderBy(x => x.fstname);
        }

        public async Task<Customer> GetCustomerByIdAsync(string id)
        {
            var item = await Repositoty.FindByConditionAync(o => o.idCustomer.Equals(id));
            return item.DefaultIfEmpty(new Customer())
                    .FirstOrDefault();
        }
        public async Task CreateCustomerAsync(Customer item)
        {
            Repositoty.Create(item);
            await Repositoty.SaveAsync();
        }

        public async Task UpdateCustomerAsync(Customer item)
        {
            Repositoty.Update(item);
            await Repositoty.SaveAsync();
        }

        public async Task DeleteCustomerAsync(Customer item)
        {
            Repositoty.Delete(item);
            await Repositoty.SaveAsync();
        }


    }
}
