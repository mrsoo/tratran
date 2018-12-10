using ShoeEcommerce.Data.Infrastructure;
using ShoeEcommerce.Model.AdminManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeEcommerce.Data.Repository
{
    public interface IRegisterNotifyReposiory : IRepository<RegisterNotify>
    {
        Task<string> GetNextIdAsync();

        Task<IEnumerable<RegisterNotify>> GetNoticeUnCheckAsync();
    }

    public class RegisterNotifyRepsitory : RepositoryBase<RegisterNotify>, IRegisterNotifyReposiory
    {
        public RegisterNotifyRepsitory(ShoeEcommerceDBContext shoeEcommerceDBContext) : base(shoeEcommerceDBContext)
        {
        }

        public async Task<string> GetNextIdAsync()
        {
            var listacc = (await this.FindAllAsync()).Select(p => p.id);
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

        public async Task<IEnumerable<RegisterNotify>> GetNoticeUnCheckAsync()
        {
            return await FindByConditionAync(p => p.Checked == false);
        }
    }
}