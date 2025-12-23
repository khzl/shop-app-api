using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Models.Common
{
    public class Price
    {
        public decimal Value { get; private set; }
        public string Currency { get; private set; } = "USD";

        public Price(decimal value, string cuurency = "USD")
        {
            if (value < 0)
            
                throw new ArgumentException("Price Cannot Be Negative");
                Value = value;
                Currency = cuurency;
        }

        // For EF Core 
        private Price()
        {

        }

        public static implicit operator decimal(Price price) => price.Value;
        public static implicit operator Price(decimal value) => new Price(value);

        public override string ToString() => $"{Value:C}";
    }
}
