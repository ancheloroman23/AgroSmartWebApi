using AgroSmart.Core.Application.Dtos.Crop;
using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Net;

namespace AgroSmart.Core.Application.Features.Crops.Queries.GetByIdQuery
{
    public class GetCropByIdQuery:IRequest<Response<CropDTO>>
    {
        public int Id { get; set; }
    }

    public class GetCropByIdQueryHandler : IRequestHandler<GetCropByIdQuery, Response<CropDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Crop> _repository;

        public GetCropByIdQueryHandler(IMapper mapper, IGenericRepository<Crop> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<CropDTO>> Handle(GetCropByIdQuery request, CancellationToken cancellationToken)
        {
            var crop = await _repository.GetByIdAsync(request.Id);
            if (crop == null)
            {
                throw new ApiException("No hay cultivos con el id: " + request.Id, (int)HttpStatusCode.NotFound);
            }

            var cropDto = _mapper.Map<CropDTO>(crop);
            return new Response<CropDTO>(cropDto);
        }
    }
}
