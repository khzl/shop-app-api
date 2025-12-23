using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Models.Model
{
    public class Customers
    {
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? EncryptedEmail { get; set; }


        // Relations 
        public ICollection<Orders> Orders { get; set; } = new List<Orders>();
        public ICollection<Payments> Payments { get; set; } = new List<Payments>();
        public Carts? Cart { get; set; } // add relationship with cart
    }
}
