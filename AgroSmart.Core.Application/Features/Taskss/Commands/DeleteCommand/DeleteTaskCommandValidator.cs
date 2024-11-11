using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSmart.Core.Application.Features.Taskss.Commands.DeleteCommand
{
    public class DeleteTaskCommandValidator :AbstractValidator<DeleteTasksCommand>
    {
        public DeleteTaskCommandValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio")
                .NotNull().WithMessage("{PropertyName} no puede estar nulo");

        }
    }
}
