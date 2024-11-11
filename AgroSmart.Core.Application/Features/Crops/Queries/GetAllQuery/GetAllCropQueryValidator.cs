using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSmart.Core.Application.Features.Crops.Queries.GetAllQuery
{
    public class GetAllCropQueryValidator : AbstractValidator<GetAllCropQuery>
    {
        public GetAllCropQueryValidator()
        {
            
        }
    }
}
