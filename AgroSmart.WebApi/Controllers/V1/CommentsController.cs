using AgroSmart.Core.Application.Features.Commentss.Commands.CreateCommand;
using AgroSmart.Core.Application.Features.Commentss.Commands.UpdateCommand;
using AgroSmart.Core.Application.Features.Commentss.Queries.GetAllQuery;
using AgroSmart.Core.Application.Features.Foros.Commands.CreateCommand;
using AgroSmart.Core.Application.Features.Foros.Commands.UpdateCommand;
using AgroSmart.Core.Application.Features.Foros.Queries.GetAllQuery;
using AgroSmart.Core.Application.Features.Foros.Queries.GetProp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace AgroSmart.WebApi.Controllers.V1
{
    [Authorize]
    public class CommentsController : BaseApiController
    {
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
                  Summary = "Creacion de Comentario",
                  Description = "Recibe los parametros necesarios para crear un nuevo comentario"
         )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateCommentsCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
