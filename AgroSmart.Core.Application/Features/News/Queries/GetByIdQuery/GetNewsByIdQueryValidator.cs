using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSmart.Core.Application.Features.News.Queries.GetByIdQuery
{
    public class GetNewsByIdQueryValidator : AbstractValidator<GetNewsByIdQuery>
    {
        public GetNewsByIdQueryValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio")
                .NotNull().WithMessage("{PropertyName} no puede estar nulo");
        }
    }
}
