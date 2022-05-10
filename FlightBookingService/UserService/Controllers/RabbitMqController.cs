using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.ViewModel;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMqController : ControllerBase
    {
        IPublishEndpoint _ipublishEndpoint;

        public RabbitMqController(IPublishEndpoint ipublishEndpoint)
        {
            _ipublishEndpoint = ipublishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            await _ipublishEndpoint.Publish<Order>(order);
            return Ok();
        }


    }
}
