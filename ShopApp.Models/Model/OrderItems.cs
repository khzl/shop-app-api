using ShopApp.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Models.Model
{
    public class OrderItems
    {
        public int OrderItemId { get; set; }

        public int Quantity { get; set; }

        public Price UnitPrice { get; set; } = new Price(0);
        // FK 
        public int OrderId { get; set; }
        public Orders? Order { get; set; }

        //FK 
        public int ProductId { get; set; }
        public Products? Product { get; set; }

    }
}
