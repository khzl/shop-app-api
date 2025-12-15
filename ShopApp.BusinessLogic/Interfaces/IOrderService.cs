using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.Models.DTOs;
using ShopApp.Models.Model;

namespace ShopApp.BusinessLogic.Interfaces
{
    public interface IOrderService
    {
        // signture for method 
        int AddOrder(OrderDTO orderDTO);
        Orders? GetById(int Id);
    }
}
