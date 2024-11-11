using AgroSmart.Core.Application.Dtos.Accounts;
using AgroSmart.Core.Application.Enums;
using AgroSmart.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace AgroSmart.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [SwaggerTag("Sistema de Membresia")]
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;        

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;            
        }

        [HttpPost("Authentication")]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Login de usuario",
            Description = "Incio de sesion para los usuarios del sistema"
        )]

        public async Task<IActionResult> Authentication(AuthenticationRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Debes mandar toda la informacion");
                }
                var response = await _accountService.AuthenticateWebApiAsync(request);
                if (response.HasError)
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, response.Error);
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        [HttpPost("RegisterDeveloper")]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Creacion de un usuario de tipo Developer",
            Description = "Se envia los parametros necesarios para crear un usuario de tipo Developer"
         )]

        public async Task<IActionResult> RegisterAdmin([FromBody]RegisterRequest register)
        {
            try
            {
                register.SelectRole = (int)Roles.Developer;
                if (!ModelState.IsValid)
                {
                    return BadRequest("Envie los datos correctamente");
                }
                var response = await _accountService.RegisterAsync(register, null);
                if (response.HasError)
                {
                    return BadRequest(response.Error);
                }
                return StatusCode(StatusCodes.Status201Created, "Developer creado con exito");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        [HttpPost("RegisterClient")]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Creación de un usuario de tipo Cliente",
            Description = "Se envían los parámetros necesarios para crear un usuario de tipo Cliente"
        )]
        public async Task<IActionResult> RegisterClient([FromBody]RegisterRequest register)
        {
            try
            {
                register.SelectRole = (int)Roles.Client; // Asignar rol de cliente
                if (!ModelState.IsValid)
                {
                    return BadRequest("Envíe los datos correctamente");
                }
                var response = await _accountService.RegisterAsync(register, null);
                if (response.HasError)
                {
                    return BadRequest(response.Error);
                }
                return StatusCode(StatusCodes.Status201Created, "Cliente creado con éxito");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "El usuario fue creado correctamente!");
            }
        }


    }
}