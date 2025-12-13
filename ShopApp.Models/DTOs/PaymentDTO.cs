using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Models.DTOs
{
    public class PaymentDTO
    {
        public int PaymentId { get; set; }
        public List<PaymentDTO> Payment { get; set; } = new List<PaymentDTO>();

    }
}
