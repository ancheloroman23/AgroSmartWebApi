using AgroSmart.Core.Application.Features.Foros.Queries.GetProp;
using AgroSmart.Core.Application.Features.Taskss.Commands.CreateCommand;
using AgroSmart.Core.Application.Features.Taskss.Commands.UpdateCommand;
using AgroSmart.Core.Application.Features.Taskss.Queries.GetAllQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace AgroSmart.WebApi.Controllers.V1
{
    [Authorize]
    public class TasksController : BaseApiController
    {
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
                 Summary = "Creacion de Tarea/Actividad",
                 Description = "Recibe los parametros necesarios para crear una nueva Tarea/Actividad"
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateTasksCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
                 Summary = "Actualizacion de Tarea/Actividad",
                 Description = "Recibe los parametros necesarios para actualizar una Tarea/Actividad"
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateTasksCommand command)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("User/{userId}")]
        [SwaggerOperation(
             Summary = "Listado de Tareas/Actividades por usuario",
             Description = "Obtiene el listado de las Tarea/Actividad creadas por el usuario"
         )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(string userId)
        {
            return Ok(await Mediator.Send(new GetAllTasksQuery { UserId = userId}));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
             Summary = "Tarea/Actividad por id",
             Description = "Obtiene una Tarea/Actividad por id"
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
