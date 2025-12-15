using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Models.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal? Price { get; set; } = 0;

        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}
