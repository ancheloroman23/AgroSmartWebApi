using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AgroSmart.Core.Application.Dtos.Accounts
{
    public class RegisterRequest
    {
        [SwaggerParameter(Description = "El nombre de la persona a quien se le creara la cuenta")]
        public string FirstName { get; set; } = null!;
        [SwaggerParameter(Description = "El apellido de la persona a quien se le creara la cuenta")]
        public string LastName { get; set; } = null!;
        [SwaggerParameter(Description = "El nombre de usuario de la persona a quien se le creara la cuenta")]
        public string UserName { get; set; } = null!;
        [SwaggerParameter(Description = "El correo electronico de la persona a quien se le creara la cuenta")]
        public string Email { get; set; } = null!;
        [SwaggerParameter(Description = "La imagen de la persona a quien se le creara la cuenta")]
        public string ImageUser { get; set; } = null!;
        [SwaggerParameter(Description = "La contraseña de la persona a quien se le creara la cuenta")]
        public string Password { get; set; } = null!;
        [SwaggerParameter(Description = "La contraseña de la persona a quien se le creara la cuenta")]
        public string ConfirmPassword { get; set; } = null!;        
        
        [JsonIgnore]
        public bool IsActive { get; set; } = true;
        [JsonIgnore]
        public int SelectRole { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Password != ConfirmPassword)
            {
                yield return new ValidationResult("Las contraseñas no coinciden.", new[] { nameof(Password), nameof(ConfirmPassword) });
            }
        }
    }
}
