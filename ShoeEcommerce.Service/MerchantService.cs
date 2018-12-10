using ShoeEcommerce.Data.Repository;
using ShoeEcommerce.Model.Users;
using ShoeEcommerce.Model.ViewModel.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoeEcommerce.Service
{
    public interface IMerchantService
    {
        Task<IEnumerable<Merchant>> GetAllMerchantsAsync();
        Merchant GetMerchantByIdAsync(string id);
        //Task<MerchantsExtended> GetMerchantsWithDetailsAsync(Guid MerchantsId);
        Task CreateMerchantAsync(Merchant item);
        Task UpdateMerchantAsync(Merchant item);
        Task DeleteMerchantAsync(Merchant item);
        Task<bool> SignUpAsync(RegisterMerchantModelView model);
    }
    public class MerchantService : IMerchantService
    {
        private IMerchantRepository Repository;

        public MerchantService(IMerchantRepository repository)
        {
            Repository = repository;
        }

        public async Task CreateMerchantAsync(Merchant item)
        {
            item.idMerchant = await Repository.GetNextIdAsync();
            Repository.Create(item);
            await Repository.SaveAsync();
        }

        public async Task DeleteMerchantAsync(Merchant item)
        {
            Repository.Delete(item);
           await Repository.SaveAsync();
        }

        public Task<IEnumerable<Merchant>> GetAllMerchantsAsync()
        {
            return Repository.FindAllAsync();
        }

        public Merchant GetMerchantByIdAsync(string id)
        {
            return Repository.Find(id);
        }

        public async Task<bool> SignUpAsync(RegisterMerchantModelView model)
        {
            return await Repository.SignUpAsync(model);
        }

        public async Task UpdateMerchantAsync(Merchant item)
        {
            Repository.Update(item);
            await Repository.SaveAsync();
        }
    }
}
