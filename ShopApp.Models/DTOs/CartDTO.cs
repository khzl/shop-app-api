using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Models.DTOs
{
    public class CartDTO
    {
        public int CartId { get; set; }

        public List<CartDTO> Cart { get; set; } = new List<CartDTO>();
    }
}
