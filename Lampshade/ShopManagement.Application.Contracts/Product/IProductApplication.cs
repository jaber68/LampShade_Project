using _0_Framwork.Application;
using System.Collections;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        OperationResult IsStock(long Id);
        OperationResult NotInStock(long Id);
        EditProduct GetDetails(long Id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
       List<ProductViewModel> GetProducts();
    }
}
