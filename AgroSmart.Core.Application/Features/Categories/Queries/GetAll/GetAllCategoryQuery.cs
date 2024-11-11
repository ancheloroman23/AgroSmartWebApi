using AgroSmart.Core.Application.Dtos.Category;
using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSmart.Core.Application.Features.Categories.Queries.GetAll
{
    public class GetAllCategoryQuery: IRequest<Response<List<CategoryDTO>>>
    {
    }

    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, Response<List<CategoryDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Category> _repository;

        public GetAllCategoryQueryHandler(IMapper mapper, IGenericRepository<Category> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<List<CategoryDTO>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.ListAsync();
            if (!categories.Any())
            {
                throw new ApiException("No se encontraron categorias");
            }

            var catDTO = _mapper.Map<List<CategoryDTO>>(categories);
            return new Response<List<CategoryDTO>>(catDTO);
        }
    }
}
