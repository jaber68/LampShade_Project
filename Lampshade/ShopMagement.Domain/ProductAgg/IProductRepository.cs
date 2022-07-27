﻿using _0_Framwork.Domain;
using ShopManagement.Application.Contracts.Product;

namespace ShopMagement.Domain.ProductAgg
{
    public interface IProductRepository:IRepository<long , Product>
    {
        EditProduct GetDetails(long id);
        List<ProductViewModel> GetProducts();
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
