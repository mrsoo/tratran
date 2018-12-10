using ShoeEcommerce.Data.Repository;
using ShoeEcommerce.Model.AdminManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoeEcommerce.Service
{
    public interface IRegisterNotifyService
    {
        Task<IEnumerable<RegisterNotify>> GetAllRegisterNotifyAsync();
        //Task<AccountsExtended> GetAccountsWithDetailsAsync(Guid AccountsId);
        Task CreateRegisterNotifyAsync(RegisterNotify item);
        Task UpdateRegisterNotifyAsync(RegisterNotify item);
        Task DeleteRegisterNotifyAsync(RegisterNotify item);
        RegisterNotify GetRegisterNotifyById(string id);
        Task<IEnumerable<RegisterNotify>> GetUncheckedNoticeAsync();
        RegisterNotify Find(string id);
    }
    public class RegisterNotifyService:IRegisterNotifyService
    {
        private IRegisterNotifyReposiory Repository;

        public RegisterNotifyService(IRegisterNotifyReposiory repository)
        {
            this.Repository = repository;
        }

        public async Task CreateRegisterNotifyAsync(RegisterNotify item)
        {
            item.id = await Repository.GetNextIdAsync();
            Repository.Create(item);
            await Repository.SaveAsync();
        }

        public async Task DeleteRegisterNotifyAsync(RegisterNotify item)
        {
            Repository.Delete(item);
            await Repository.SaveAsync();
        }

        public RegisterNotify Find(string id) => Repository.Find(id);

        public Task<IEnumerable<RegisterNotify>> GetAllRegisterNotifyAsync()
        {
            return Repository.FindAllAsync();
        }

        public RegisterNotify GetRegisterNotifyById(string id)
        {
            return Repository.Find(id);
        }

        public async Task<IEnumerable<RegisterNotify>> GetUncheckedNoticeAsync()
        {
            return await Repository.GetNoticeUnCheckAsync();
        }

        public async Task UpdateRegisterNotifyAsync(RegisterNotify item)
        {
            Repository.Update(item);
            await Repository.SaveAsync();
        }
    }
}
