using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Models.Model
{
    public class ProductCarts
    {
        // FK
        public int ProductId { get; set; }
        public Products? Products { get; set; }

        // FK
        public int CartId { get; set; }
        public Carts? Carts { get; set; }

    }
}
