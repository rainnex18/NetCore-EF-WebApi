using DAL.Interface;
using DAL.Models.DB;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigurationService
    {
        public static IServiceCollection AddDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AcmeDbContext>(
                        options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            services.AddScoped<IReviewRepository, ReviewRepository> ();
            services.AddScoped<IProductRepository, ProductRepository> ();
            services.AddScoped<ICustomerRepository, CustomerRepository> ();

            return services;
        }
    }
}
