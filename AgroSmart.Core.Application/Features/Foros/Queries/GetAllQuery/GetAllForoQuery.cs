using AgroSmart.Core.Application.Dtos.Foro;
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

namespace AgroSmart.Core.Application.Features.Foros.Queries.GetAllQuery
{
    public class GetAllForoQuery : IRequest<Response<List<ForoDTO>>>
    {
    }

    public class GetAllForoQueryHandler : IRequestHandler<GetAllForoQuery, Response<List<ForoDTO>>>
    {

        private readonly IMapper _mapper;
        private readonly IGenericRepository<Foro> _repository;

        public GetAllForoQueryHandler(IMapper mapper, IGenericRepository<Foro> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<List<ForoDTO>>> Handle(GetAllForoQuery request, CancellationToken cancellationToken)
        {
            var foros = await _repository.ListAsync();
            if (!foros.Any())
            {
                throw new ApiException("No hay foros encontrados", (int)HttpStatusCode.NotFound);
            }

            var foroDto = _mapper.Map<List<ForoDTO>>(foros);
            return new Response<List<ForoDTO>>(foroDto);
        }
    }
}
