using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Interfaces.Services;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Net;

namespace AgroSmart.Core.Application.Features.Crops.Commands.CreateCommand
{
    public class CreateCropCommand:IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Variety { get; set; }
        public DateTime DateCrop { get; set; }
        public DateTime? DateHarvest { get; set; }
        public string? UserId { get; set; }
    }

    public class CreateCropCommandHandler : IRequestHandler<CreateCropCommand, Response<int>>
    {
        private readonly IGenericRepository<Crop> _repository;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public CreateCropCommandHandler(IGenericRepository<Crop> repository, IAccountService accountService, IMapper mapper)
        {
            _repository = repository;
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCropCommand request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                throw new ApiException("No hay user con el id: " + request.UserId, (int)HttpStatusCode.NotFound);
            }

            var crop = _mapper.Map<Crop>(request);

            var cropAdded = _repository.AddAsync(crop);

            return new Response<int>(cropAdded.Id);
            
        }
    }
}
