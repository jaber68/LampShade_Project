using _0_Framwork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopMagement.Domain.ProductAgg;
using ShopManagement.Application.Contracts.Product;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository

    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProduct GetDetails(long id)
        {
            return _context.Products.Select(x => new EditProduct
            {
                Id = x.Id,
                Name = x.Name,  
                Code = x.Code,
                Description = x.Description,
                Picture = x.Picture,
                ShortDescription = x.ShortDescription,
                Keywords = x.Keywords,
                Slug = x.Slug,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                MetaDescription = x.MetaDescription,
                UnitPrice = x.UnitPrice,

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _context.Products.Select(x => new ProductViewModel
            {

                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _context.Products.Include(x => x.Category).Select(x => new ProductViewModel { 
            
             Id = x.Id,
             Code = x.Code,
             Category = x.Category.Name,
             UnitPrice = x.UnitPrice,
             Name = x.Name,
             Picture = x.Picture,
             CategoryId = x.CategoryId,
             IsInStock = x.IsInStock,
             CreationDate = x.CreationDate.ToString()
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                 query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                 query = query.Where(x => x.Code.Contains(searchModel.Code));

            if (searchModel.CategoryId != 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
