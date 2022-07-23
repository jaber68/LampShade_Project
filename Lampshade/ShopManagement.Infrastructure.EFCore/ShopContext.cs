using Microsoft.EntityFrameworkCore;
using ShopMagement.Domain.ProductAgg;
using ShopMagement.Domain.ProductCategoryAgg;
using ShopMagement.Domain.ProductPictureAgg;
using ShopManagement.Infrastructure.EFCore.Mapping;

namespace ShopManagement.Infrastructure.EFCore
{
    public class ShopContext: DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
