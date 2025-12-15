using ShopApp.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.Models.Model;

namespace ShopApp.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _Db;

        public ProductRepository(AppDbContext Db)
        {
            _Db = Db;
        }

        public int Add(Products products)
        {
            _Db.Products.Add(products);
            _Db.SaveChanges();
            return products.ProductId;
        }

        public void Delete(int productId)
        {
            var product = _Db.Products.Find(productId);
            if (product != null)
            {
                _Db.Products.Remove(product);
                _Db.SaveChanges();
            }
        }

        public List<Products> GetAll()
        {
            return _Db.Products.ToList();
        }

        public Products? GetById(int Id)
        {
            return _Db.Products.Find(Id);
        }

        public void Update(Products products)
        {
            _Db.Products.Update(products);
            _Db.SaveChanges();
        }
    }
}
