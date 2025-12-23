using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Models.Model
{
    public class Carts
    {
        public int CartId { get; set; }

        // FK For Customer 
        public int CustomerId { get; set; }
        public Customers? Customer { get; set; }
        public ICollection<ProductCarts> ProductCarts { get; set; } = new List<ProductCarts>();
    }
}
