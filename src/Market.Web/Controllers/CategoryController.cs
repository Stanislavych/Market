using Market.Application.Category.Commands;
using Market.Application.Category.Queries;
using Market.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Market.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            var query = new GetAllCategoriesQuery();
            var categories = await _mediator.Send(query);

            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] AddCategoryCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var categoryId = await _mediator.Send(command);

            return Ok(categoryId);
        }
    }
}
