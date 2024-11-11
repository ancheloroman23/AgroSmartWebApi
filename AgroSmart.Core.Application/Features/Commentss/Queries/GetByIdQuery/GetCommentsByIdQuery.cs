using AgroSmart.Core.Application.Dtos.Comments;
using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Net;

namespace AgroSmart.Core.Application.Features.Commentss.Queries.GetByIdQuery
{
    public class GetCommentsByIdQuery : IRequest<Response<CommentsDTO>>
    {
        public int Id { get; set; }
    }

    public class GetCommentsByIdQueryHandler : IRequestHandler<GetCommentsByIdQuery, Response<CommentsDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Comments> _repository;

        public GetCommentsByIdQueryHandler(IMapper mapper, IGenericRepository<Comments> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<CommentsDTO>> Handle(GetCommentsByIdQuery request, CancellationToken cancellationToken)
        {
            var comments = await _repository.GetByIdAsync(request.Id);
            if (comments == null)
            {
                throw new ApiException("No hay comentario con el id: " + request.Id, (int)HttpStatusCode.NotFound);
            }

            var commentsDto = _mapper.Map<CommentsDTO>(request);
            return new Response<CommentsDTO>(commentsDto);
        }
    }
}