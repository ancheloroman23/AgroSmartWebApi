using AgroSmart.Core.Application.Features.News.Commands.CreateCommand;
using AgroSmart.Core.Application.Features.News.Commands.UpdateCommand;
using AgroSmart.Core.Application.Features.News.Queries.GetAllQuery;
using AgroSmart.Core.Application.Features.News.Queries.GetByIdQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace AgroSmart.WebApi.Controllers.V1
{
    [Authorize]
    public class NewsController : BaseApiController
    {
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
                 Summary = "Creacion de Informacion Agricola",
                 Description = "Recibe los parametros necesarios para crear una nueva Informacion Agricola"
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateNewsCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
                 Summary = "Actualizacion de Informacion Agricola",
                 Description = "Recibe los parametros necesarios para actualizar una Informacion Agricola"
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateNewsCommand command)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [SwaggerOperation(
             Summary = "Listado de cultivo de la Informacion Agricola",
             Description = "Obtiene el listado de las Informaciones Agricolas creadas"
         )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllNewsQuery()));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
             Summary = "Informacion Agricola por id",
             Description = "Obtiene una Informacion Agricola por id"
         )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetNewsByIdQuery { Id = id }));
        }
    }
}
