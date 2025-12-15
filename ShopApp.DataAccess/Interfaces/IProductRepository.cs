using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.Models.Model;

namespace ShopApp.DataAccess.Interfaces
{
    public interface IProductRepository
    {
        // Signture for Method 
        Products? GetById(int Id);
        List<Products> GetAll();
        int Add(Products products);
        void Update(Products products);
        void Delete(int Id);
    }
}
