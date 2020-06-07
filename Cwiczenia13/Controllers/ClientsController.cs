using Cwiczenia13.DTOs.Requests;
using Cwiczenia13.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia13.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly IOrderDbService _service;

        public ClientsController(IOrderDbService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddOrder(AddOrderRequest request, int idKlient)
        {
            return Ok(_service.AddOrder(request, idKlient));
        }

    }
}