using Microsoft.AspNetCore.Mvc;
using ShopApp.BusinessLogic.Interfaces;
using ShopApp.BusinessLogic.Services;
using ShopApp.Models.DTOs;

namespace ShopApp.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult Add(CustomerDTO customerDTO)
        {
            var Id = _customerService.Add(customerDTO);
            return Ok(new { CustomerId = Id });
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_customerService.GetAll());
    }
}
