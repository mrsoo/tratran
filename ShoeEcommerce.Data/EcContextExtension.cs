using ShoeEcommerce.Model.Users;
using ShoeEcommerce.Data;
using System.Collections.Generic;

namespace EcMnt.Models
{
    public static class EcContextExtension
    {
        public static void EnsureDataSeeded(this ShoeEcommerceDBContext context)
        {
            var list = new List<Customer>()
            {
                new Customer(){ fstname="Trần", lstname="Tra", idCustomer="1", phone="0984518825", },
                new Customer(){ fstname="Trần", lstname="Tra", idCustomer="2", phone="0984518825"}
            };
            list.ForEach(p => context.Customers.Add(p));
            context.SaveChanges();
        }
        public static void EnsureDataDeleted(this ShoeEcommerceDBContext context)
        {
            context.Database.EnsureDeleted();
        }
    }
}
