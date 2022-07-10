using ShopMagement.Domain.ProductCategoryAgg;
using ShopManagement.Application.Contracts.ProductCategory;
using System.Linq.Expressions;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ShopContext _context;

        public ProductCategoryRepository(ShopContext context)
        {
            _context = context;
        }
        public void Create(ProductCategory entity)
        {
            _context.ProductCategories.Add(entity);
           
    }

        public bool Exists(Expression<Func<ProductCategory, bool>> experssion)
        {
           return _context.ProductCategories.Any(experssion);
        }

        public ProductCategory Get(long id)
        {
            return _context.ProductCategories.Find(id);
        }

        public List<ProductCategory> GetAll()
        {
            return _context.ProductCategories.ToList();
        }

        public EditProductCategory GetDetails(long id)
        {
            return _context.ProductCategories.Select(x => new EditProductCategory(){
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Keywords = x.Keywords,
                Picture = x.Picture,
                PictureAlt = x.PictureTitle,
                PictureTitle = x.PictureTitle,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug

            }).FirstOrDefault(x => x.Id == id);
            }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _context.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Picture = x.Picture,
                Name = x.Name,
                CreationDate = x.CreationDate.ToString()
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name)) ;
            query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
