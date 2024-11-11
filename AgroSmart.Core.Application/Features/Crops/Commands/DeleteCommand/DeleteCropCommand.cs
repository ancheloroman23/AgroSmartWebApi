using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using MediatR;
using System.Net;

namespace AgroSmart.Core.Application.Features.Crops.Commands.DeleteCommand
{
    public class DeleteCropCommand:IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteCropCommandHandler : IRequestHandler<DeleteCropCommand, Response<int>>
    {
        private readonly IGenericRepository<Crop> _repository;

        public DeleteCropCommandHandler(IGenericRepository<Crop> repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteCropCommand request, CancellationToken cancellationToken)
        {
            var crop = await _repository.GetByIdAsync(request.Id);
            if (crop == null)
            {
                throw new ApiException("No existe registro con el id: " + request.Id, (int)HttpStatusCode.NotFound);
            }
            await _repository.DeleteAsync(crop);
            return new Response<int>(crop.Id);
        }
    }
}
