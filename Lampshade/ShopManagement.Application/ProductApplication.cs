﻿using _0_Framwork.Application;
using ShopMagement.Domain.ProductAgg;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessage.DouplicatedRecord);

            var slug = command.Slug.Slugify();
            var product = new Product(command.Name, command.Code, command.ShortDescription,
                command.Description, command.Picture, command.PictureAlt, command.PictureTitle,
                 command.CategoryId, slug, command.Keywords, command.MetaDescription);
            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operation.Succedded();
             
        }

        public OperationResult Edit(EditProduct command)
        {
                       var operation = new OperationResult();
            var product = _productRepository.Get(command.Id);
            if (product == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (_productRepository.Exists(x => x.Name == command.Name && x.Id == command.Id))
                return operation.Failed(ApplicationMessage.DouplicatedRecord);


            var slug = command.Slug.Slugify();
             product.Edit (command.Name, command.Code, command.ShortDescription,
                command.Description, command.Picture, command.PictureAlt, command.PictureTitle,
                 command.CategoryId, slug, command.Keywords, command.MetaDescription);
            _productRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }

      

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }
    }
}
