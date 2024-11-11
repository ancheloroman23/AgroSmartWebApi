using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSmart.Core.Application.Features.Crops.Commands.UpdateCommand
{
    public class UpdateCropCommandValidator : AbstractValidator<UpdateCropCommand>
    {
        public UpdateCropCommandValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio")
                .NotNull().WithMessage("{PropertyName} no puede estar nulo");

            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio")
                .NotNull().WithMessage("{PropertyName} no puede estar nulo");

            RuleFor(e => e.Variety)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio")
                .NotNull().WithMessage("{PropertyName} no puede estar nulo");

            RuleFor(e => e.UserId)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio")
                .NotNull().WithMessage("{PropertyName} no puede estar nulo");

            RuleFor(e => e.DateCrop)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio")
                .NotNull().WithMessage("{PropertyName} no puede estar nulo");
        }
    }
}
