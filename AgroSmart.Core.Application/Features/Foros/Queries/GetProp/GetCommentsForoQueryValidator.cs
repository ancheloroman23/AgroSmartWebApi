using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSmart.Core.Application.Features.Foros.Queries.GetProp
{
    public class GetCommentsForoQueryValidator : AbstractValidator<GetCommentsForoQuery>
    {
        public GetCommentsForoQueryValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio");
        }
    }
}
