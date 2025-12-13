using ShopApp.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Models.Model
{
    public class Products
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Price Price { get; set; } = new Price(0);

        // FK (Many-To-One)
        public int CategoryId { get; set; }
        public Categories? Categories { get; set; }

        // Relations 
        public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
        public ICollection<ProductCarts> ProductCarts { get; set; } = new List<ProductCarts>();
    }
}
