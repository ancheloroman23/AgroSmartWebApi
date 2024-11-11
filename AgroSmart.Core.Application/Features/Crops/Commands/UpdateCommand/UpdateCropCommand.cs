using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Interfaces.Services;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using MediatR;
using System.Net;

namespace AgroSmart.Core.Application.Features.Crops.Commands.UpdateCommand
{
    public class UpdateCropCommand:IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Variety { get; set; }
        public DateTime DateCrop { get; set; }
        public DateTime? DateHarvest { get; set; }
        public string? UserId { get; set; }
    }

    public class UpdateCropCommandHandler : IRequestHandler<UpdateCropCommand, Response<int>>
    {
        private readonly IGenericRepository<Crop> _repository;
        private readonly IAccountService _service;

        public UpdateCropCommandHandler(IGenericRepository<Crop> repository, IAccountService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task<Response<int>> Handle(UpdateCropCommand request, CancellationToken cancellationToken)
        {
            var crop = await _repository.GetByIdAsync(request.Id);
            if (crop == null)
            {
                throw new ApiException("No existe registro con el id: "+request.Id, (int)HttpStatusCode.NotFound);
            }
            var user = await _service.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                throw new ApiException("No existe usuario con el id: "+request.UserId, (int)HttpStatusCode.NotFound);
            }

            crop.Name = request.Name != null ? request.Name : crop.Name;
            crop.Variety = request.Variety != null ? request.Variety : crop.Variety;
            crop.DateCrop = request.DateCrop != null ? request.DateCrop : crop.DateCrop;
            crop.DateHarvest = request.DateHarvest != null ? request.DateHarvest : crop.DateHarvest;
            crop.UserId = request.UserId != null ? request.UserId : crop.UserId;

            await _repository.UpdateAsync(crop);
            return new Response<int>(crop.Id);
        }
    }
}
