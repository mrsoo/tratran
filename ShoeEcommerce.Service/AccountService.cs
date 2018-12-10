using ShoeEcommerce.Data.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ShoeEcommerce.Model.Accounts;
using ShoeEcommerce.Model.ViewModel.Login;
using ShoeEcommerce.Common;

namespace ShoeEcommerce.Service
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(string id);
        //Task<AccountsExtended> GetAccountsWithDetailsAsync(Guid AccountsId);
        Task CreateAccountAsync(Account item);
        Task UpdateAccountAsync(Account item);
        Task DeleteAccountAsync(Account item);
        Account isAuthenticated(string username,string passwd);
        Task<bool> RegisterAsync(RegisterModelView modelView);

    }
    public class AccountService : IAccountService
    {
        IAccountRepository Repositoty;
        public AccountService(IAccountRepository accountRepository)
        {
            this.Repositoty = accountRepository;
        }
        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            var item = await Repositoty.FindAllAsync();
            return item.OrderBy(x => x.username);
        }

        public async Task<Account> GetAccountByIdAsync(string id)
        {
            var item = await Repositoty.FindByConditionAync(o => o.idAccount.Equals(id));
            return item.DefaultIfEmpty(new Account())
                    .FirstOrDefault();
        }

        //public async Task<AccountsExtended> GetAccountsWithDetailsAsync(Guid AccountsId)
        //{
        //    var Accounts = await GetAccountsByIdAsync(AccountsId);

        //    return new AccountsExtended(Accounts)
        //    {
        //        Accounts = await RepositoryContext.Accounts
        //            .Where(a => a.AccountsId == AccountsId).ToListAsync()
        //    };
        //}

        public async Task CreateAccountAsync(Account item)
        {
            item.idAccount = await Repositoty.GetNextId();
            Repositoty.Create(item);
            await Repositoty.SaveAsync();
        }

        public async Task UpdateAccountAsync(Account item)
        {
            Repositoty.Update(item);
            await Repositoty.SaveAsync();
        }

        public async Task DeleteAccountAsync(Account item)
        {
            Repositoty.Delete(item);
            await Repositoty.SaveAsync();
        }
        //login
        
        public Account isAuthenticated(string username, string passwd)
        {

            var list = Repositoty.GetAccountByUsenameAsync(username).Result.ToList();
            //test
            if (username == "root@gmail.com")
            {
                if(list.Exists(p=>p.passwd == passwd)) return list.FirstOrDefault() ; 
            }

            string encryptedpass = ExtensionTools.GetMD5(passwd);
            foreach (var item in list)
            {
                if (item.passwd.Equals(encryptedpass)) return item;
            }
            return null;
        }

        public async Task<bool> RegisterAsync(RegisterModelView modelView)
        {
            return await Repositoty.RegisterAsync(modelView);
        }
    }
}
