using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Models.Model
{
    public class Payments
    {
        public int PaymentId { get; set; }
        public string? TypePayment { get; set; }
        public decimal Amount { get; set; }

        // FK 
        public int CustomerId { get; set; }
        public Customers? Customer { get; set; }

        // One - to - One With Order 
        public int OrderId { get; set; }
        public Orders? Order { get; set; }

    }
}
