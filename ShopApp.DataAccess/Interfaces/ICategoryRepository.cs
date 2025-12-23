using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.Models.Model;

namespace ShopApp.DataAccess.Interfaces
{
    public interface ICategoryRepository
    {
        // Signature For Method 
        Categories? GetById(int CategoryId);
        List<Categories> GetAll();
        List<Categories> GetWithProducts();
        Categories? GetWithProducts(int CategoryId);
        int Add(Categories Category);
        void Update(Categories Category);
        void Delete(int CategoryId);
        bool Exists(int CategoryId);
        List<Products> GetCategoryProducts(int CategoryId);
    }
}
