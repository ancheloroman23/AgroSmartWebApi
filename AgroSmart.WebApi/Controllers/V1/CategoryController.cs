using AgroSmart.Core.Application.Features.Categories.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgroSmart.WebApi.Controllers.V1
{
    [Authorize]
    public class CategoryController : BaseApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllCategoryQuery()));
        }
    }
}
