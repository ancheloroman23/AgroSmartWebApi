using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Interfaces.Services;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AgroSmart.Core.Application.Features.Foros.Commands.UpdateCommand
{
    public class UpdateForoCommand : IRequest<Response<int>>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
    }

    public class UpdateForoCommandHandler : IRequestHandler<UpdateForoCommand, Response<int>>
    {
        private readonly IGenericRepository<Foro> _repository;
        private readonly IAccountService _service;
        private readonly IGenericRepository<Category> _catRepo;

        public UpdateForoCommandHandler(IGenericRepository<Foro> repository, IAccountService service, IGenericRepository<Category> catRepo)
        {
            _repository = repository;
            _service = service;
            _catRepo = catRepo;
        }

        public async Task<Response<int>> Handle(UpdateForoCommand request, CancellationToken cancellationToken)
        {

            var user = await _service.GetUserByIdAsync(request.UserId);

            if (user == null)
            {
                throw new ApiException("No hay usuario con este id: " + request.UserId, (int)HttpStatusCode.BadRequest);
            }

            var category = await _catRepo.GetByIdAsync(request.CategoryId);
            if (user == null)
            {
                throw new ApiException("No hay categoria con este id: " + request.CategoryId, (int)HttpStatusCode.BadRequest);
            }

            var foro = await _repository.GetByIdAsync(request.Id);
            if (foro == null)
            {
                throw new ApiException("No existe foro con el id: " + request.Id, (int)HttpStatusCode.NotFound);
            }

            foro.Content = request.Content;
            foro.CategoryId = request.CategoryId;
            foro.Title = request.Title;
            foro.UserId = request.UserId;


            await _repository.UpdateAsync(foro);
            return new Response<int>(foro.Id);
        }
    }
}
