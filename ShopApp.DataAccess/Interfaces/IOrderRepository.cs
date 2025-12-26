using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.Models.Model;

namespace ShopApp.DataAccess.Interfaces
{
    public interface IOrderRepository
    {
        // Signature For Methods
        Orders? GetByIdWithItems(int OrderId);
        List<Orders> GetAll();
        List<Orders> GetByCustomerId(int CustomerId);
        int Add(Orders order);
        void Update(Orders order);
        void Delete(int OrderId);
        decimal GetTotalSalesByDateRange(DateTime StartDate, DateTime EndDate);
    }
}
