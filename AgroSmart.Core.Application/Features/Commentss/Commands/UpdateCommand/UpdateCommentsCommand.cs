using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Features.Crops.Commands.UpdateCommand;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Interfaces.Services;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using MediatR;
using System.Net;


namespace AgroSmart.Core.Application.Features.Commentss.Commands.UpdateCommand
{
    public class UpdateCommentsCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int ForoId { get; set; }        
        public string Content { get; set; }
        public string? UserId { get; set; }
    }

    public class UpdateCommentsCommandHandler : IRequestHandler<UpdateCommentsCommand, Response<int>>
    {
        private readonly IGenericRepository<Comments> _repository;
        private readonly IAccountService _service;
        private readonly IGenericRepository<Foro> _repositoryForo;


        public UpdateCommentsCommandHandler(IGenericRepository<Comments> repository, IAccountService service, IGenericRepository<Foro> repositoryForo)
        {
            _repository = repository;
            _service = service;
            _repositoryForo = repositoryForo;
        }

        public async Task<Response<int>> Handle(UpdateCommentsCommand request, CancellationToken cancellationToken)
        {
            var comments = await _repository.GetByIdAsync(request.Id);
            if (comments == null)
            {
                throw new ApiException("No existe comentario con el id: " + request.Id, (int)HttpStatusCode.NotFound);
            }
            var user = await _service.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                throw new ApiException("No existe usuario con el id: " + request.UserId, (int)HttpStatusCode.NotFound);
            }

            var foro = await _repositoryForo.GetByIdAsync(request.ForoId);
            if (foro == null)
            {
                throw new ApiException("No existe Foro con el ID:" + request.ForoId, (int)HttpStatusCode.NotFound);
            }

            comments.UserId = request.UserId != null ? request.UserId : comments.UserId;
            comments.ForoId = request.ForoId != null ? request.ForoId : comments.ForoId;
            comments.Content = request.Content != null ? request.Content : comments.Content;

            await _repository.UpdateAsync(comments);
            return new Response<int>(comments.Id);
        }
    }
}