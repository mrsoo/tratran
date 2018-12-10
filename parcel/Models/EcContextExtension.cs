using EcMnt.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models
{
    public static class EcContextExtension
    {
        public static void EnsureDataSeeded(this EcContext context)
        {
            var list = new List<Customer>()
            {
                new Customer(){ fstname="Trần", lstname="Tra", idCustomer="1", phone="0984518825", },
                new Customer(){ fstname="Trần", lstname="Tra", idCustomer="2", phone="0984518825"}
            };
            list.ForEach(p => context.Customers.Add(p));
            context.SaveChanges();
        }
        public static void EnsureDataDeleted(this EcContext context)
        {
            context.Database.EnsureDeleted();
        }
    }
}
