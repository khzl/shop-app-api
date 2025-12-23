using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.DataAccess.Interfaces;
using ShopApp.Models.Model;
using ShopApp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ShopApp.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopDbContext _Db;

        public CategoryRepository(ShopDbContext db)
        {
            _Db = db; 
        }

        public int Add(Categories Category)
        {
            _Db.Categories.Add(Category);
            _Db.SaveChanges();
            return Category.CategoryId;
        }

        public void Delete(int CategoryId)
        {
            var Category = _Db.Categories.Find(CategoryId);
            if (Category != null)
            {
                _Db.Categories.Remove(Category);
                _Db.SaveChanges();
            }
        }

        public bool Exists(int CategoryId)
        {
            return _Db.Categories.Any(category => category.CategoryId == CategoryId);
        }

        public List<Categories> GetAll()
        {
            return _Db.Categories.ToList();
        }

        public Categories? GetById(int CategoryId)
        {
            return _Db.Categories.Find(CategoryId);
        }

        public List<Products> GetCategoryProducts(int CategoryId)
        {
            return _Db.Products
                .Where(product => product.CategoryId == CategoryId)
                .ToList();
        }

        public void Update(Categories Category)
        {
            _Db.Categories.Update(Category);
            _Db.SaveChanges();
        }

        public List<Categories> GetWithProducts()
        {
            return _Db.Categories
                .Include(category => category.Products)
                .ToList();
        }

        public Categories? GetWithProducts(int CategoryId)
        {
            return _Db.Categories
                .Include(category => category.Products)
                .FirstOrDefault(category => category.CategoryId == CategoryId);
        }


    }
}
