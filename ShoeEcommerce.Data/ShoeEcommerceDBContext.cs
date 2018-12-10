using Microsoft.EntityFrameworkCore;
using ShoeEcommerce.Model.Accounts;
using ShoeEcommerce.Model.AdminManager;
using ShoeEcommerce.Model.Advertisements;
using ShoeEcommerce.Model.Bills;
using ShoeEcommerce.Model.Extensions;
using ShoeEcommerce.Model.OnlinePost;
using ShoeEcommerce.Model.Products;
using ShoeEcommerce.Model.Repositories;
using ShoeEcommerce.Model.Users;

namespace ShoeEcommerce.Data
{
    public class ShoeEcommerceDBContext : DbContext
    {
        public ShoeEcommerceDBContext(DbContextOptions<ShoeEcommerceDBContext> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<RankVip> RankVips { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Position> Positions { get; set; }
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
        public DbSet<ShoeEcommerce.Model.Repositories.Repository> Repositories { get; set; }
        public DbSet<ExportForm> ExportForms { get; set; }
        public DbSet<ImportForm> ImportForms { get; set; }
        public DbSet<ItemEplist> ItemEplists { get; set; }
        public DbSet<ItemIplist> ItemIplists { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Link_ImgStore> Link_ImgStores { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<RegisterNotify> RegisterNotifies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
