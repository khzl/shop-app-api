using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.Models.Model;

namespace ShopApp.DataAccess.Interfaces
{
    public interface IProductRepository
    {
        // Signature for Method 
        public int Add(Products Product);
        public void Delete(int ProductId);
        public List<Products> GetAll();
        public List<Products> GetByCategory(int CategoryId);
        public Products? GetById(int ProductId);
        public List<Products> SearchProducts(string SearchTerm);
        public void Update(Products Product);
        public bool ProductExists(int ProductId);
    }
}
