using AgroSmart.Core.Application.Features.Foros.Commands.CreateCommand;
using AgroSmart.Core.Application.Features.Foros.Commands.UpdateCommand;
using AgroSmart.Core.Application.Features.Foros.Queries.GetAllQuery;
using AgroSmart.Core.Application.Features.Foros.Queries.GetProp;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace AgroSmart.WebApi.Controllers.V1
{
    [Authorize]
    public class ForoController : BaseApiController
    {
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
                 Summary = "Creacion de Foro",
                 Description = "Recibe los parametros necesarios para crear un nuevo Foro"
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateForoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
                 Summary = "Actualizacion de foro",
                 Description = "Recibe los parametros necesarios para actualizar un foro"
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateForoCommand command)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [SwaggerOperation(
             Summary = "Listado de foros",
             Description = "Obtiene el listado de los foros creados"
         )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllForoQuery()));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
             Summary = "Foro por id",
             Description = "Obtiene un foro por id y sus comentarios"
         )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetCommentsForoQuery { Id = id }));
        }
    }
}
