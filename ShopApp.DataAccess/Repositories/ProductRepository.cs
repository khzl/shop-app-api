using ShopApp.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.Models.Model;
using ShopApp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace ShopApp.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopDbContext _Db;

        public ProductRepository(ShopDbContext Db)
        {
            _Db = Db;
        }

        public int Add(Products Product)
        {
            _Db.Products.Add(Product);
            _Db.SaveChanges();
            return Product.ProductId;
        }

        public void Delete(int ProductId)
        {
            var product = _Db.Products.Find(ProductId);
            if (product != null)
            {
                _Db.Products.Remove(product);
                _Db.SaveChanges();
            }
        }

        public List<Products> GetAll()
        {
            return _Db.Products
                .Include(product => product.Categories)
                .ToList();
        }

        public List<Products> GetByCategory(int CategoryId)
        {
            return _Db.Products
                .Where(product => product.CategoryId == CategoryId)
                .Include(product => product.Categories)
                .ToList();
        }

        public Products? GetById(int ProductId)
        {
            return _Db.Products
                .Include(product => product.Categories)
                .FirstOrDefault(product => product.ProductId == ProductId);
        }

        public List<Products> SearchProducts(string SearchTerm)
        {
            // checking for input 
            if(string.IsNullOrWhiteSpace(SearchTerm))
                return new List<Products>();

            // Clear Search term
            var CleanSearchTerm = SearchTerm.Trim();
            
            //build query with null safety 
            return _Db.Products
                .Where(product => 
                 (product.Name != null && EF.Functions.Like(product.Name , $"%{CleanSearchTerm}%"))||
                 (product.Description != null && EF.Functions.Like(product.Description , $"%{CleanSearchTerm}%")))
                .Include(product => product.Categories)
                .AsNoTracking() // Performance 
                .ToList();
        }

        public void Update(Products Product)
        {
            var ExistingProduct = _Db.Products.Find(Product.ProductId);
            if(ExistingProduct != null)
            {
                _Db.Entry(ExistingProduct).CurrentValues.SetValues(Product);
                _Db.SaveChanges();
            }
        }

        public bool ProductExists(int ProductId)
        {
            return _Db.Products.Any(product => product.ProductId == ProductId);
        }

    }
}
