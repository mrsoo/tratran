using ShoeEcommerce.Data.Repository;
using ShoeEcommerce.Model.Accounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoeEcommerce.Service
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAllAddressAsync();
        //Task<AccountsExtended> GetAccountsWithDetailsAsync(Guid AccountsId);
        Task CreateAddressAsync(Address item);
        Task UpdateAddressAsync(Address item);
        Task DeleteAddressAsync(Address item);
        Address GetAddressById(string id);

    }
    public class AddressService : IAddressService
    {
        private IAddressRepository Repository;

        public AddressService(IAddressRepository repository)
        {
            Repository = repository;
        }

        public async Task CreateAddressAsync(Address item)
        {
            item.id = await Repository.GetNextId();
            Repository.Create(item);
            await Repository.SaveAsync();
        }

        public async Task DeleteAddressAsync(Address item)
        {
            Repository.Delete(item);
            await Repository.SaveAsync();
        }

        public Address GetAddressById(string id)
        {
            return Repository.Find(id);
        }

        public async Task<IEnumerable<Address>> GetAllAddressAsync()
        {
            return await  Repository.FindAllAsync();
        }

        public async Task UpdateAddressAsync(Address item)
        {
            Repository.Update(item);
            await Repository.SaveAsync();
        }
    }
}
