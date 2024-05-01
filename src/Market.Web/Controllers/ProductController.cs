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

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var query = new GetAllProductsQuery();
            var products = await _mediator.Send(query);

            return Ok(products);
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult<int>> Create([FromBody] AddProductCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var productId = await _mediator.Send(command);

            return productId;
        }

        [HttpGet("GetProduct/{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var query = new GetProductByIdQuery { Id = id };
            var product = await _mediator.Send(query);

            return Ok(product);
        }

        [HttpGet("GetProducts/{categoryName}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByCategoryName(string categoryName)
        {
            var query = new GetProductsByCategoryNameQuery { CategoryName = categoryName };
            var products = await _mediator.Send(query);

            return Ok(products);
        }

        [HttpPut("UpdateProduct")]
        public async Task<ActionResult<Product>> Update([FromBody] UpdateProductCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var product = await _mediator.Send(command);

            return Ok(product);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var command = new DeleteProductCommand {Id=id };
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
