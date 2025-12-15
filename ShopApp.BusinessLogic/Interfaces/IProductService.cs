using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.Models.Model;
using ShopApp.Models.DTOs;

namespace ShopApp.BusinessLogic.Interfaces
{
    public interface IProductService
    {
        // signture for methods
        int Add(ProductDTO productDTO);
        List<Products> GetAll();
    }
}
