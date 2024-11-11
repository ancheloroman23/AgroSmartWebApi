using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Interfaces.Services;
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

namespace AgroSmart.Core.Application.Features.Foros.Commands.CreateCommand
{
    public class CreateForoCommand : IRequest<Response<int>>
    {
        public string Title { get; set; }
        public string? Content { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
    }

    public class CreateForoCommandHandler : IRequestHandler<CreateForoCommand, Response<int>>
    {

        private readonly IMapper _mapper;
        private readonly IGenericRepository<Foro> _repository;
        private readonly IAccountService _accountService;
        private readonly IGenericRepository<Category> _catRepo;

        public CreateForoCommandHandler(IMapper mapper, IGenericRepository<Foro> repository, IAccountService accountService, IGenericRepository<Category> catRepo)
        {
            _mapper = mapper;
            _repository = repository;
            _accountService = accountService;
            _catRepo = catRepo;
        }

        public async Task<Response<int>> Handle(CreateForoCommand request, CancellationToken cancellationToken)
        {

            var user = await _accountService.GetUserByIdAsync(request.UserId);

            if (user == null)
            {
                throw new ApiException("No hay usuario con este id: " + request.UserId, (int)HttpStatusCode.BadRequest);
            }

            var category = await _catRepo.GetByIdAsync(request.CategoryId);
            if (user == null)
            {
                throw new ApiException("No hay categoria con este id: " + request.CategoryId, (int)HttpStatusCode.BadRequest);
            }

            var foro = _mapper.Map<Foro>(request);

            foro = await _repository.AddAsync(foro);

            return new Response<int>(foro.Id);
            
        }
    }
}
