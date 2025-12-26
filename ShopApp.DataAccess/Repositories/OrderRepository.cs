using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Data;
using ShopApp.DataAccess.Interfaces;
using ShopApp.Models.Model;

namespace ShopApp.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopDbContext _Db;

        public OrderRepository(ShopDbContext Db)
        {
            _Db = Db;
        }

        public int Add(Orders Order)
        {
            _Db.Orders.Add(Order);
            _Db.SaveChanges();
            return Order.OrderId;
        }

        public Orders? GetByIdWithItems(int OrderId)
        {
            return _Db.Orders
                .Include(order => order.OrderItems)
                .ThenInclude(orderItem => orderItem.Product)
                .Include(order => order.Customer)
                .Include(order => order.Payment)
                .FirstOrDefault(order => order.OrderId == OrderId);
        }

        public List<Orders> GetByCustomerId(int CustomerId)
        {
            return _Db.Orders
                .Include(order => order.OrderItems)
                .Where(order => order.CustomerId == CustomerId)
                .OrderByDescending(order => order.OrderDate)
                .ToList();
        }

        public List<Orders> GetAll()
        {
            return _Db.Orders
                .Include(order => order.Customer)
                .Include(order => order.OrderItems)
                .OrderByDescending(order => order.OrderDate)
                .ToList();
        }

        public void Update(Orders Order)
        {
            _Db.Orders.Update(Order);
            _Db.SaveChanges();
        }

        public void Delete(int OrderId)
        {
            var Order = _Db.Orders.Find(OrderId);
            if(Order != null)
            {
                _Db.Orders.Remove(Order);
                _Db.SaveChanges();
            }
        }

        public decimal GetTotalSalesByDateRange(DateTime StartDate,DateTime EndDate)
        {
            return _Db.Orders
                .Where(order => order.OrderDate >= StartDate && order.OrderDate <= EndDate)
                .Sum(order => order.Amount);
        }


    }
}
