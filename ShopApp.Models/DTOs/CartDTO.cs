using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Models.DTOs
{
    public class CartDTO
    {
        public int CartId { get; set; }

        public int CustomerId { get; set; }
        public List<CartItemDTO> CartItems { get; set; } = new List<CartItemDTO>();
    }
}
