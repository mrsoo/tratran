using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoeEcommerce.Model.Users;
using ShoeEcommerce.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using ShoeEcommerce.Model.Accounts;

namespace ShoeEcommerce.Data.Migrations
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ShoeEcommerceDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<ShoeEcommerceDBContext>>()))
            {

                if (!context.Merchants.Any())
                context.Merchants.AddRange(
                new Merchant()
                {
                    idMerchant = "noone",
                    fstname = "test",
                    lstname = "test",
                    phone = "nonumber",
                    storename = "nostore",
                    stt = true

                },
                new Merchant()
                {
                    idMerchant = "1",
                    fstname = "adas",
                    lstname = "acafc",
                    phone = "01887762600",
                    storename = "kynak",
                    stt = true

                }

                );
                    context.SaveChanges();
                if (!context.Customers.Any())
                
                context.Customers.AddRange(
                    new Customer
                    {
                        idCustomer = "noone",
                        fstname = "noname",
                        lstname = "noname",
                        phone = "none",
                        stt = true


                    },
                    new Customer
                    {
                        idCustomer = "1",
                        fstname = "Steve",
                        lstname = "Myzus",
                        phone = "090",
                        stt = true

                    },
                    new Customer
                    {
                        idCustomer = "2",
                        lstname = "Dog",
                        fstname = "Thief",
                        phone = "090",
                        stt = true

                    },
                    new Customer
                    {
                        idCustomer = "3",
                        lstname = "Cat",
                        fstname = "Thief",
                        phone = "090",
                        stt = true

                    }
                    );
                context.SaveChanges();
                var date = DateTime.Now;
                if (!context.Accounts.Any())
                    context.Accounts.AddRange(

                    new Model.Accounts.Account()
                    {
                        idAccount = "root",
                        username = "root@gmail.com",
                        passwd = "rootuser",
                        IdMerchant = "noone",
                        rankVip = "default",
                        rate = 1,
                        idCustomer = "noone",
                        avt_path = "dasda",
                        CreatedDate = date,
                        stt = true
                    },
                new Model.Accounts.Account()
                {
                    idAccount = "1",
                    username = "kynak@gmail.com",
                    passwd = "passuser",
                    IdMerchant = "noone",
                    rankVip = "default",
                    rate = 1,
                    idCustomer = "1",
                    avt_path = "dasda",
                    CreatedDate = date,
                    stt = true
                },
                new Model.Accounts.Account()
                {
                    idAccount = "2",
                    username = "wifekynak@gmail.com",
                    passwd = "passuser",
                    IdMerchant = "1",
                    rankVip = "default",
                    rate = 1,
                    idCustomer = "noone",
                    avt_path = "dasda",
                    CreatedDate = date,
                    stt=true
                    
                });
                context.SaveChanges();
                if (!context.RankVips.Any())
                {
                    context.RankVips.Add(new RankVip()
                    {
                        idRank = "default",
                        viewRate = 15,
                        stt=true
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
