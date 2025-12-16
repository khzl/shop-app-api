using Microsoft.AspNetCore.Mvc;
using ShopApp.BusinessLogic.Interfaces;
using ShopApp.BusinessLogic.Services;
using ShopApp.Models.DTOs;

namespace ShopApp.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult Add(ProductDTO productDTO)
        {
            var Id = _productService.Add(productDTO);
            return Ok(new { ProductId = Id });
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_productService.GetAll());
    }
}
