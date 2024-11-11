using AgroSmart.Core.Application.Dtos.Comments;
using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Net;

namespace AgroSmart.Core.Application.Features.Commentss.Queries.GetAllQuery
{
    public class GetAllCommentsQuery : IRequest<Response<List<CommentsDTO>>>
    {
    }

    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, Response<List<CommentsDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Comments> _repository;

        public GetAllCommentsQueryHandler(IMapper mapper, IGenericRepository<Comments> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        async Task<Response<List<CommentsDTO>>> IRequestHandler<GetAllCommentsQuery, Response<List<CommentsDTO>>>.Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _repository.ListAsync();
            if (!comments.Any())
            {
                throw new ApiException("No hay ningun comentario registrado", (int)HttpStatusCode.NotFound);
            }

            var commentsDto = _mapper.Map<List<CommentsDTO>>(comments);
            return new Response<List<CommentsDTO>>(commentsDto);
        }
    }
}