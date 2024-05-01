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

        [HttpGet("GetAllCategories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            var query = new GetAllCategoriesQuery();
            var categories = await _mediator.Send(query);

            return Ok(categories);
        }

        [HttpGet("GetCategory/{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var query = new GetCategoryByIdQuery { Id = id };
            var category = await _mediator.Send(query);

            return Ok(category);
        }

        [HttpPost("CreateCategory")]
        public async Task<ActionResult<int>> Create([FromBody] AddCategoryCommand command)
        {
            var categoryId = await _mediator.Send(command);

            return Ok(categoryId);
        }

        [HttpPut("UpdateCategory")]
        public async Task<ActionResult<Category>> Update([FromBody] UpdateCategoryCommand command)
        {
            var category = await _mediator.Send(command);

            return Ok(category);
        }

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var command = new DeleteCategoryCommand { Id = id };
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
