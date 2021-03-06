﻿using ShoeEcommerce.Data.Infrastructure;
using ShoeEcommerce.Model.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeEcommerce.Data.Repository
{
    public interface IAddressRepository : IRepository<Address>
    {

        Task<string> GetNextId();

    }
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(ShoeEcommerceDBContext shoeEcommerceDBContext) : base(shoeEcommerceDBContext)
        {
        }

        public async Task<string> GetNextId()
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
        
    }
}
