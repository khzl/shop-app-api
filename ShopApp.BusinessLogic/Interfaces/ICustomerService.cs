using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.Models.Model;
using ShopApp.Models.DTOs;

namespace ShopApp.BusinessLogic.Interfaces
{
    public interface ICustomerService
    {
        // signture for methods
        int Add(CustomerDTO customerDTO);
        List<Customers> GetAll();
    }
}
