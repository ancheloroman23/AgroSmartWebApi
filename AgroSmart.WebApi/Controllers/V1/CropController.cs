using AgroSmart.Core.Application.Features.Crops.Commands.CreateCommand;
using AgroSmart.Core.Application.Features.Crops.Commands.UpdateCommand;
using AgroSmart.Core.Application.Features.Crops.Queries.GetAllQuery;
using AgroSmart.Core.Application.Features.Crops.Queries.GetByIdQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace AgroSmart.WebApi.Controllers.V1
{
    [Authorize]
    public class CropController : BaseApiController
    {
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
                 Summary = "Creacion de Cultivo",
                 Description = "Recibe los parametros necesarios para crear un nuevo Cultivo"
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateCropCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
                 Summary = "Actualizacion de Cutivo",
                 Description = "Recibe los parametros necesarios para actualizar un Cultivo"
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCropCommand command)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("User/{userId}")]
        [SwaggerOperation(
             Summary = "Listado de cultivo del usuario",
             Description = "Obtiene el listado de los cultivos creados por el usuario logueado"
         )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(string userId)
        {
            return Ok(await Mediator.Send(new GetAllCropQuery { UserId = userId}));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
             Summary = "Cultivo por id",
             Description = "Obtiene un cultivo por id"
         )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetCropByIdQuery { Id = id }));
        }
    }
}
