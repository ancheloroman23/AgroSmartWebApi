

using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Features.Crops.Commands.CreateCommand;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Interfaces.Services;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace AgroSmart.Core.Application.Features.Commentss.Commands.CreateCommand
{
    public class CreateCommentsCommand : IRequest<Response<int>>
    {
        public int ForoId { get; set; }
        public string Content { get; set; }
        public string? UserId { get; set; }
    }

    public class CreateCommentsCommandHandler : IRequestHandler<CreateCommentsCommand, Response<int>>
    {
        private readonly IGenericRepository<Comments> _repository;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public CreateCommentsCommandHandler(IGenericRepository<Comments> repository, IAccountService accountService, IMapper mapper)
        {
            _repository = repository;
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCommentsCommand request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                throw new ApiException("No hay user con el id: "+request.UserId, (int)HttpStatusCode.NotFound);
            }

            var comments = _mapper.Map<Comments>(request);

            var commentsAdded = _repository.AddAsync(comments);

            return new Response<int>(commentsAdded.Id);

        }
    }
}
