using System;
using System.Collections.Generic;
using System.Text;
using ShopApp.DataAccess.Repositories;
using ShopApp.Models.Model;
using ShopApp.Models.DTOs;
using ShopApp.BusinessLogic.Interfaces;
using ShopApp.Models.Common;
using System.Linq;
namespace ShopApp.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly UnitOfWork _unitOfWork;

        public OrderService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int AddOrder(OrderDTO orderDTO)
        {
            // validate all order items 
            foreach(var orderItem in orderDTO.OrderItems)
            {
                if (!orderItem.UnitPrice.HasValue)
                {
                    throw new ArgumentException($"UnitPrice Is Required For ProductId:  {orderItem.ProductId}",
                        nameof(orderDTO.OrderItems));
                }
            }

            var order = new Orders
            {
                CustomerId = orderDTO.CustomerId,
                OrderItems = orderDTO.OrderItems.Select(orderItem =>
                new OrderItems
                {
                    ProductId = orderItem.ProductId,
                    Quantity = orderItem.Quantity,
                    UnitPrice = new Price(orderItem.UnitPrice!.Value) // use .value safely
                }).ToList()
            };
            return _unitOfWork.Orders.Add(order);
        }

        public Orders? GetById(int Id) => _unitOfWork.Orders.GetByIdWithItems(Id);
    }
}
