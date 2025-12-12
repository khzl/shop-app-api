using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Models.Model
{
    public class Categories
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }

        public string? PictureUrl { get; set; }

        public ICollection<Products> Products { get; set; } = new List<Products>();
    }
}
