using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Models.Common
{
    public class Price
    {
        public decimal Value { get; private set; }

        public Price(decimal value)
        {
            if (value < 0)
            {
                throw new Exception("Price Cannot Be Negative");
            }
            Value = value;
        }
    }
}
