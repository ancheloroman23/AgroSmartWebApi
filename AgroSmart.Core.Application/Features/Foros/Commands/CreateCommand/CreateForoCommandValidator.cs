using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSmart.Core.Application.Features.Foros.Commands.CreateCommand
{
    public class CreateForoCommandValidator : AbstractValidator<CreateForoCommand>
    {
        public CreateForoCommandValidator()
        {
            RuleFor(e => e.UserId)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .NotNull().WithMessage("{PropertyName} no puede ser nulo");

            RuleFor(e => e.Content)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .NotNull().WithMessage("{PropertyName} no puede ser nulo");

            RuleFor(e => e.CategoryId)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .NotNull().WithMessage("{PropertyName} no puede ser nulo");


            RuleFor(e => e.Title)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                .MaximumLength(40).WithMessage("{PropertyName} no puede exceder los 40 caracteres");
        }
    }
}
