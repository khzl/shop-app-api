using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Models.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
        public PaymentDTO? Payment { get; set; }

    }
}
