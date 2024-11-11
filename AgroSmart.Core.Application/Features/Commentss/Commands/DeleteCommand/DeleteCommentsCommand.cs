using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using MediatR;
using System.Net;

namespace AgroSmart.Core.Application.Features.Commentss.Commands.DeleteCommand
{
    public class DeleteCommentsCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteCommentsCommandHandler : IRequestHandler<DeleteCommentsCommand, Response<int>>
    {
        private readonly IGenericRepository<Comments> _repository;

        public DeleteCommentsCommandHandler(IGenericRepository<Comments> repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteCommentsCommand request, CancellationToken cancellationToken)
        {
            var comments = await _repository.GetByIdAsync(request.Id);
            if (comments == null)
            {
                throw new ApiException("No existe registro con el id: " + request.Id, (int)HttpStatusCode.NotFound);
            }
            await _repository.DeleteAsync(comments);
            return new Response<int>(comments.Id);
        }
    }
}
