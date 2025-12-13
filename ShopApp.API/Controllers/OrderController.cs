using Microsoft.AspNetCore.Mvc;
using ShopApp.BusinessLogic.Services;
using ShopApp.Models.DTOs;

namespace ShopApp.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult AddOrder(OrderDTO orderDTO)
        {
            var Id = _orderService.AddOrder(orderDTO);
            return Ok(new { OrderId = Id });
        }

        [HttpGet("{Id}")]
        public IActionResult GetOrder(int Id)
        {
            var Order = _orderService.GetById(Id);
            return Order is null ? NotFound() : Ok(Order);
        }
    }
}
