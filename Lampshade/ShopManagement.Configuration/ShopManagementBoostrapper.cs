using Microsoft.Extensions.DependencyInjection;
using ShopMagement.Domain.ProductCategoryAgg;

using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Application;

namespace ShopManagement.Configuration
{
    public class ShopManagementBoostrapper
    {
      

        public static void Configure(IServiceCollection services , string connectionString)
        {
         services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
           services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }

      
        }
    }