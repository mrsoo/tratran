using Microsoft.Extensions.DependencyInjection;
using ShoeEcommerce.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeEcommerce.Service
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, LoggerService>();
        }
        public static void ConfigureAllTableService(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IEmailRepository,EmailRepository>();

            services.AddScoped<IMerchantService, MerchantService>();
            services.AddScoped<IMerchantRepository, MerchantRepository>();

            services.AddScoped<IRegisterNotifyService, RegisterNotifyService>();
            services.AddScoped<IRegisterNotifyReposiory, RegisterNotifyRepsitory>();
            
        }
    }
}
