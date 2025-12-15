using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.DataAccess.Interfaces;
using ShopApp.Models.DTOs;
using ShopApp.Models.Model;
using ShopApp.Models.Common;
using ShopApp.BusinessLogic.Interfaces;
using System.Runtime.CompilerServices;

namespace ShopApp.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Add(ProductDTO productDTO)
        {
            // validate all required fields 
            if (string.IsNullOrWhiteSpace(productDTO.ProductName))
            {
                throw new ArgumentException("Product Name Is Required ", nameof(productDTO.ProductName));
            }

            if (!productDTO.Price.HasValue)
            {
                throw new ArgumentException("Price Is Required ", nameof(productDTO.Price));
            }

            var product = new Products
            {
                Name = productDTO.ProductName,
                Price = new Price(productDTO.Price.Value)
            };
             
            return _unitOfWork.Products.Add(product);
        }

        public List<Products> GetAll()
        {
            return _unitOfWork.Products.GetAll();
        }
    }
}
