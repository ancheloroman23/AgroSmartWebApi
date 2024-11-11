using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSmart.Core.Application.Features.Commentss.Commands.CreateCommand
{
    public class CreateCommentsCommandValidator:AbstractValidator<CreateCommentsCommand>
    {
        public CreateCommentsCommandValidator()
        {
            RuleFor(e => e.Content)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio")
                .MaximumLength(3000)
                .WithMessage("No puede exceder 3000 caracteres");

            RuleFor(e => e.UserId)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio");

            RuleFor(e => e.ForoId)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio");
        }
    }
}
