using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Models.DTOs
{
    public class OrderDTO
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }
}
