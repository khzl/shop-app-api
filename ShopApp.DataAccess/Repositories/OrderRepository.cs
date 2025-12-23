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

        public int Add(Orders order)
        {
            _Db.Orders.Add(order);
            _Db.SaveChanges();
            return order.OrderId;
        }

        public Orders? GetByIdWithItems(int Id)
        {
            return _Db.Orders
                .Include(order => order.OrderItems)
                .FirstOrDefault(order => order.OrderId == Id);
        }

    }
}
