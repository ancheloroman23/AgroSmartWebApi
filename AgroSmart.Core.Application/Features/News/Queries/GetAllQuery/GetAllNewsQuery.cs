using AgroSmart.Core.Application.Dtos.Crop;
using AgroSmart.Core.Application.Dtos.New;
using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Features.Crops.Queries.GetAllQuery;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AgroSmart.Core.Application.Features.News.Queries.GetAllQuery
{
    public class GetAllNewsQuery : IRequest<Response<List<NewDTO>>>
    {
    }

    public class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, Response<List<NewDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<New> _repository;

        public GetAllNewsQueryHandler(IMapper mapper, IGenericRepository<New> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }



        async Task<Response<List<NewDTO>>> IRequestHandler<GetAllNewsQuery, Response<List<NewDTO>>>.Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {
            var news = await _repository.ListAsync();
            if (!news.Any())
            {
                throw new ApiException("No hay ninguna noticia registrado");
            }

            var newDto = _mapper.Map<List<NewDTO>>(news);
            return new Response<List<NewDTO>>(newDto);
        }
    }
}