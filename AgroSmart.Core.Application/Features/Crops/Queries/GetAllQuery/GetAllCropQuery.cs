using AgroSmart.Core.Application.Dtos.Crop;
using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Interfaces.Services;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Net;

namespace AgroSmart.Core.Application.Features.Crops.Queries.GetAllQuery
{
    public class GetAllCropQuery : IRequest<Response<List<CropDTO>>>
    {
        public string UserId { get; set; }
    }

    public class GetAllCropQueryHandler : IRequestHandler<GetAllCropQuery, Response<List<CropDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Crop> _repository;
        private readonly IAccountService _accountService;

        public GetAllCropQueryHandler(IMapper mapper, IGenericRepository<Crop> repository, IAccountService accountService)
        {
            _mapper = mapper;
            _repository = repository;
            _accountService = accountService;
        }



        async Task<Response<List<CropDTO>>> IRequestHandler<GetAllCropQuery, Response<List<CropDTO>>>.Handle(GetAllCropQuery request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                throw new ApiException("Usuarios con el id: "+ request.UserId, (int)HttpStatusCode.BadRequest);
            }

            var crops = await _repository.ListAsync();
            if (!crops.Any())
            {
                throw new ApiException("No hay ningun cultivo registrado", (int)HttpStatusCode.NotFound);
            }

            var cropsDto = _mapper.Map<List<CropDTO>>(crops);

            var cropByUser = cropsDto.Where(e => e.UserId == request.UserId).ToList();
            return new Response<List<CropDTO>>(cropByUser);
        }
    }
}
