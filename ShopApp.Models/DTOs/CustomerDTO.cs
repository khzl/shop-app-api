using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Models.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Email { get; set; }

        public List<CustomerDTO> Customer { get; set; } = new List<CustomerDTO>();
    }
}
