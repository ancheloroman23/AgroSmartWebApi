using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSmart.Core.Application.Features.Commentss.Queries.GetByIdQuery
{
    public class GetCommentByIdQueryValidator : AbstractValidator<GetCommentsByIdQuery>
    {
        public GetCommentByIdQueryValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio");

        }
    }
}
