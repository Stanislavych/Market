using Market.Application.Product.Commands;
using Market.Application.Product.Queries;
using Market.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Market.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var query = new GetAllProductsQuery();
            var products = await _mediator.Send(query);

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] AddProductCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var productId = await _mediator.Send(command);

            return productId;
        }
    }
}
