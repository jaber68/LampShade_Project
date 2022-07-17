using _0_Framework.Application;
using _0_Framwork.Application;
using ShopMagement.Domain.ProductCategoryAgg;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Infrastructure.EFCore.Repository;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
                var operation=new OperationResult();
                if (_productCategoryRepository.Exists(x => x.Name ==command.Name))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد..لطفا مجددا تلاش نمایید");

#pragma warning disable CS8604 // Possible null reference argument.
            var slug = command.Slug.Slugify();
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning disable CS8604 // Possible null reference argument.
            var productCategory = new ProductCategory(command.Name, command.Description, command.Picture
                    ,command.PictureTitle, command.MetaDescription, 
                   command.Keywords, command.PictureAlt, slug);
#pragma warning restore CS8604 // Possible null reference argument.

            _productCategoryRepository.Create(productCategory);
                _productCategoryRepository.SaveChanges();
                return operation.Succedded();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.Get(command.Id);

            if (productCategory == null)
                return operation.Failed("رکورد با اطلاعات وارد شده یافت نشد لطفا مجددا تلاش نمایید");
            if (_productCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
           return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد لطفا دوباره تلاش نمایید");

#pragma warning disable CS8604 // Possible null reference argument.
            var slug = command.Slug.Slugify();
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning disable CS8604 // Possible null reference argument.
            productCategory.Edit(command.Name, command.Description, command.Picture
                        , command.PictureTitle, command.MetaDescription,
                         command.Keywords, command.PictureAlt, slug);
#pragma warning restore CS8604 // Possible null reference argument.

            _productCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }
      

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }

       
    }
}