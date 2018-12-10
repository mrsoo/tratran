using EcMnt.Models.Accounts;
using EcMnt.Models.Advertisements;
using EcMnt.Models.Bills;
using EcMnt.Models.Extensions;
using EcMnt.Models.OnlinePost;
using EcMnt.Models.Products;
using EcMnt.Models.Repositories;
using EcMnt.Models.Users;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcMnt.Models
{
    public class EcContext : DbContext
    {
        public EcContext(DbContextOptions<EcContext> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> Emails { get; set; }
        //public DbSet<RankVip> RankVips { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        //public DbSet<Position> Positions { get; set; }
        public DbSet<BillState> BillStates { get; set; }
        public DbSet<ItemOrderList> ItemOrderLists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<historySearch> HistorySearches { get; set; }
        public DbSet<Post> Posts{ get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Category> Categories  { get; set; }
        public DbSet<ImageProduct> ImageProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<productDetail> ProductDetails { get; set; }
        public DbSet<Repository> Repositories { get; set; }
        public DbSet<ExportForm> ExportForms { get; set; }
        public DbSet<ImportForm> ImportForms { get; set; }
        public DbSet<ItemEplist> ItemEplists { get; set; }
        public DbSet<ItemIplist> ItemIplists { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Link_ImgStore> Link_ImgStores { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
