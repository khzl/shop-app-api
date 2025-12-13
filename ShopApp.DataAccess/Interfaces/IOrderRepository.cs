using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.Models.Model;
namespace ShopApp.DataAccess.Interfaces
{
    public interface IOrderRepository
    {
        // Signture for Method 
        Orders? GetByIdWithItems(int Id);
        int Add(Orders orders);
    }
}
