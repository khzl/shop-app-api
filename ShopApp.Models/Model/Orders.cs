using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Models.Model
{
    public class Orders
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        // FK 
        public int CustomerId { get; set; }
        public Customers? Customer { get; set; }

        // One - to - One Payment 
        public Payments? Payment { get; set; }

        // One - To - Many with OrderItems
        public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();

    }
}
