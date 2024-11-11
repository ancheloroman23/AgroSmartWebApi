using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSmart.Core.Application.Features.Foros.Commands.UpdateCommand
{
    public class UpdateForoCommandValidator : AbstractValidator<UpdateForoCommand>
    {
        public UpdateForoCommandValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacia")
                .NotNull().WithMessage("{PropertyName} no puede ser nulo");

            RuleFor(e => e.Title)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacia")
                .NotNull().WithMessage("{PropertyName} no puede ser nulo");

            RuleFor(e => e.Content)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacia")
                .NotNull().WithMessage("{PropertyName} no puede ser nulo");

            RuleFor(e => e.CategoryId)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacia")
                .NotNull().WithMessage("{PropertyName} no puede ser nulo");

            RuleFor(e => e.UserId)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacia")
                .NotNull().WithMessage("{PropertyName} no puede ser nulo");


        }
    }
}
