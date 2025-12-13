using ShopApp.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Models.DTOs
{
    public class OrderItemDTO
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal? UnitPrice { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();

    }
}
