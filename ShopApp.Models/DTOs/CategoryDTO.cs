using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Models.DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public string? PictureUrl { get; set; }

        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}
