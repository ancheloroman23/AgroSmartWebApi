using FluentValidation;


namespace AgroSmart.Core.Application.Features.Commentss.Commands.UpdateCommand
{
    public class UpdateCommentsCommandValidator:AbstractValidator<UpdateCommentsCommand>
    {
        public UpdateCommentsCommandValidator()
        {
            RuleFor(e => e.Content)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio");

            RuleFor(e => e.UserId)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio");

            RuleFor(e => e.ForoId)
               .NotEmpty().WithMessage("{PropertyName} no puede estar vacio");

            RuleFor(e => e.Id)
               .NotEmpty().WithMessage("{PropertyName} no puede estar vacio");

        }
    }
}
