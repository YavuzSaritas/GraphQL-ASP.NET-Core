using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL_DotNetCore.GraphQL;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL_DotNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GraphQLController : ControllerBase
    {
        private readonly OwnerConsumer _consumer;

        public GraphQLController(OwnerConsumer consumer)
        {
            _consumer = consumer;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var owners = await _consumer.GetAllOwners();
            return Ok(owners);
        }
        
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] OwnerInput ownerInput)
        {
            var owners = await _consumer.CreateOwner(ownerInput);
            return Ok(owners);
        }
    }
}
