using AgroSmart.Core.Application.Dtos.New;
using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AgroSmart.Core.Application.Features.News.Queries.GetByIdQuery
{
    public class GetNewsByIdQuery : IRequest<Response<NewDTO>>
    {
        public int Id { get; set; }
    }

    public class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQuery, Response<NewDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<New> _repository;

        public GetNewsByIdQueryHandler(IMapper mapper, IGenericRepository<New> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<NewDTO>> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {
            var news = await _repository.GetByIdAsync(request.Id);
            if (news == null)
            {
                throw new ApiException("No hay noticia con el id: " + request.Id);
            }

            var newspDto = _mapper.Map<NewDTO>(news);
            return new Response<NewDTO>(newspDto);
        }
    }
}