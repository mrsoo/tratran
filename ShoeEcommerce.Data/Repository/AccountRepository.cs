using Microsoft.EntityFrameworkCore;
using ShoeEcommerce.Common;
using ShoeEcommerce.Data.Infrastructure;
using ShoeEcommerce.Model.Accounts;
using ShoeEcommerce.Model.Users;
using ShoeEcommerce.Model.ViewModel.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeEcommerce.Data.Repository
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<IEnumerable<Account>> GetAccountByUsenameAsync(string username);

        Task<string> GetNextId();

        Task<bool> RegisterAsync(RegisterModelView modelView);
    }

    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(ShoeEcommerceDBContext ShoeEcommerceDBContext) : base(ShoeEcommerceDBContext)
        {
        }

        public async Task<IEnumerable<Account>> GetAccountByUsenameAsync(string username)
        {
            return await ShoeEcommerceDBContext.Accounts.Where(p => p.username == username).ToListAsync();
        }

        public async Task<string> GetNextId()
        {
            var listacc = (await this.FindAllAsync()).Select(p => p.idAccount);
            int i = 1;
            var date = DateTime.Now;
            string newid = $"{date.Month}{date.Year.ToString().Substring(2)}_{i}";
            while (listacc.Where(p => p.Equals(newid)).Count() > 0)
            {
                i++;
                newid = $"{date.Month}{date.Year.ToString().Substring(2)}_{i}";
            }
            return newid;
        }

        public async Task<bool> RegisterAsync(RegisterModelView modelView)
        {
            string idcus;
            string idAcc;
            var tran = this.ShoeEcommerceDBContext.Database.BeginTransaction();
            try
            {
                //customer
                var cusRepo = new CustomerRepository(this.ShoeEcommerceDBContext);
                idcus = await cusRepo.GetNextId();
                var cus = new Customer()
                {
                    idCustomer = idcus,
                    fstname = modelView.fstname,
                    lstname = modelView.lstname,
                    phone = modelView.phone,
                    stt = true
                };
                cusRepo.Create(cus);
                await cusRepo.SaveAsync();

                //account
                idAcc = await GetNextId();
                var acc = new Account()
                {
                    idAccount = idAcc,
                    username = modelView.username,
                    passwd = ExtensionTools.GetMD5(modelView.password),
                    avt_path = ExtensionTools.GetFullPath(modelView.avt_path),
                    rankVip = "default",
                    rate = 1,
                    IdMerchant = "noone",
                    idCustomer = idcus,
                    CreatedDate = DateTime.Now,
                    stt=true
                };
                Create(acc);
                await SaveAsync();

                //email
                var EmailRepo = new EmailRepository(this.ShoeEcommerceDBContext);
                EmailRepo.Create(new Email()
                {
                    id = await EmailRepo.GetNextIdAsync(),
                    email = modelView.email,
                    IdAccount = idAcc,
                    stt=true
                });
                await EmailRepo.SaveAsync();

                //Address
                var AddressRepos = new AddressRepository(this.ShoeEcommerceDBContext);
                AddressRepos.Create(new Address()
                {
                    id = await AddressRepos.GetNextId(),
                    add_Info = modelView.add_Info,
                    City_Provine = modelView.City_Provine,
                    District_town = modelView.District_town,
                    subDistrict = modelView.subDistrict,
                    idAccount = idAcc,
                    stt=true
                });
                await AddressRepos.SaveAsync();
                tran.Commit();
                tran.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                tran.Dispose();
                return false;
            }
        }
    }
}