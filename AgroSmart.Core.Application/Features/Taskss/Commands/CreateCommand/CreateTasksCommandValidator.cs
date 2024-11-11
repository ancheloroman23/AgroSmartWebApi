using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSmart.Core.Application.Features.Taskss.Commands.CreateCommand
{
    public class CreateTasksCommandValidator : AbstractValidator<CreateTasksCommand>
    {
        public CreateTasksCommandValidator()
        {
            RuleFor(e => e.Title)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio")
                .NotNull().WithMessage("{PropertyName} no puede estar nulo");

            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio")
                .NotNull().WithMessage("{PropertyName} no puede estar nulo");

            RuleFor(e => e.Date)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio")
                .NotNull().WithMessage("{PropertyName} no puede estar nulo");

            RuleFor(e => e.UserId)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio")
                .NotNull().WithMessage("{PropertyName} no puede estar nulo");
        }
    }
}
