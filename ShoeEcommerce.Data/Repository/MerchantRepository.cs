using ShoeEcommerce.Common;
using ShoeEcommerce.Data.Infrastructure;
using ShoeEcommerce.Model.Accounts;
using ShoeEcommerce.Model.AdminManager;
using ShoeEcommerce.Model.Users;
using ShoeEcommerce.Model.ViewModel.Login;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeEcommerce.Data.Repository
{
    public interface IMerchantRepository : IRepository<Merchant>
    {
        Task<bool> SignUpAsync(RegisterMerchantModelView model);

        Task<string> GetNextIdAsync();
    }

    public class MerchantRepository : RepositoryBase<Merchant>, IMerchantRepository
    {
        public MerchantRepository(ShoeEcommerceDBContext shoeEcommerceDBContext) : base(shoeEcommerceDBContext)
        {
        }

        public async Task<string> GetNextIdAsync()
        {
            var listacc = (await this.FindAllAsync()).Select(p => p.idMerchant);
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

        public async Task<bool> SignUpAsync(RegisterMerchantModelView model)
        {
            string idMer, idAcc;
            var tran = this.ShoeEcommerceDBContext.Database.BeginTransaction();
            try
            {
                //merchant
                idMer = await this.GetNextIdAsync();
                this.Create(new Merchant()
                {
                    idMerchant = idMer,
                    fstname = model.fstname,
                    lstname = model.lstname,
                    storename = model.storename,
                    phone = model.phone,
                    website = model.website,
                    stt = false
                });
                await this.SaveAsync();
                //account Merchant
                var accRepos = new AccountRepository(this.ShoeEcommerceDBContext);
                idAcc = await accRepos.GetNextId();
                accRepos.Create(new Account()
                {
                    idAccount = idAcc,
                    username = model.username,
                    passwd = ExtensionTools.GetMD5(model.password),
                    avt_path = ExtensionTools.GetFullMerchantPath(model.avt_path),
                    rate = 1,
                    rankVip = "default",
                    CreatedDate = DateTime.Now,
                    idCustomer = "noone",
                    IdMerchant = idMer,
                    //chờ admin kiểm duyệt
                    stt = false
                });
                await accRepos.SaveAsync();
                //email
                var emailRepos = new EmailRepository(this.ShoeEcommerceDBContext);
                emailRepos.Create(new Email()
                {
                    id = await emailRepos.GetNextIdAsync(),
                    email = model.email,
                    IdAccount = idAcc,
                    stt = true
                });
                await emailRepos.SaveAsync();
                //address
                var addressRepos = new AddressRepository(this.ShoeEcommerceDBContext);
                addressRepos.Create(new Address()
                {
                    id = await addressRepos.GetNextId(),
                    add_Info = model.add_Info,
                    City_Provine = model.City_Provine,
                    District_town = model.District_town,
                    subDistrict = model.subDistrict,
                    idAccount = idAcc,
                    stt = true
                });
                await addressRepos.SaveAsync();
                //Thêm thông báo cho addmin
                var Add_on = new RegisterNotifyRepsitory(this.ShoeEcommerceDBContext);
                Add_on.Create(new RegisterNotify()
                {
                    id = await Add_on.GetNextIdAsync(),
                    id_Acc = idAcc,
                    id_Mer = idMer,
                    Checked = false,
                    createdDate = DateTime.Now,
                    stt = true
                });
                await Add_on.SaveAsync();


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