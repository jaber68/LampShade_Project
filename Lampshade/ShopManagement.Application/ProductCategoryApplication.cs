﻿using _0_Framwork.Application;
using ShopMagement.Domain.ProductCategoryAgg;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Infrastructure.EFCore.Repository;
using System.Collections.Generic;

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
                return operation.Failed(ApplicationMessage.DouplicatedRecord);

           
            var slug = command.Slug.Slugify();
            var productCategory = new ProductCategory(command.Name, command.Description,command.Picture 
                    ,command.PictureTitle, command.MetaDescription, 
                   command.Keywords, command.PictureAlt, slug);


            _productCategoryRepository.Create(productCategory);
                _productCategoryRepository.SaveChanges();
                return operation.Succedded();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.Get(command.Id);

            if (productCategory == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);
            if (_productCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
           return operation.Failed(ApplicationMessage.DouplicatedRecord);


            var slug = command.Slug.Slugify();
            productCategory.Edit(command.Name, command.Description, command.Picture
                        , command.PictureTitle, command.MetaDescription,
                         command.Keywords, command.PictureAlt, slug);


            _productCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _productCategoryRepository.GetProductCategories();
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