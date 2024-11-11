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
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AgroSmart.Core.Application.Features.Categories.Queries.GetById
{
    public class GetCategoryByIdQuery:IRequest<Response<CategoryDTO>>
    {
        public int Id { get; set; }
    }

    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Response<CategoryDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Category> _repository;

        public GetCategoryByIdQueryHandler(IMapper mapper, IGenericRepository<Category> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<CategoryDTO>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);
            if (category == null)
            {
                throw new ApiException("No hay categorias con el id: " + request.Id, (int)HttpStatusCode.NotFound);
            }

            var categoryDto = _mapper.Map<CategoryDTO>(category);
            return new Response<CategoryDTO>(categoryDto);
        }
    }
}
