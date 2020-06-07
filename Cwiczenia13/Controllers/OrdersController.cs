using System;
using System.Linq;
using Cwiczenia13.Models;
using Cwiczenia13.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia13.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderDbService _service;

        public OrdersController(IOrderDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_service.GetOrders());
        }

        [HttpGet("{Nazwisko}")]
        public IActionResult GetOrder(String Nazwisko)
        {
            return Ok(_service.GetOrders(Nazwisko));
        }

    }
}