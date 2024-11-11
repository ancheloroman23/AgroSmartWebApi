using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AgroSmart.Core.Application.Features.Foros.Commands.DeleteCommand
{
    public class DeleteForoCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteForoCommandHandler : IRequestHandler<DeleteForoCommand, Response<int>>
    {
        private readonly IGenericRepository<Foro> _repository;

        public DeleteForoCommandHandler(IGenericRepository<Foro> repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteForoCommand request, CancellationToken cancellationToken)
        {

            var foro = await _repository.GetByIdAsync(request.Id);
            if (foro == null)
            {
                throw new ApiException("No existe foro con el id: " + request.Id, (int)HttpStatusCode.BadRequest);
            }

            await _repository.DeleteAsync(foro);

            return new Response<int>(request.Id);
        }
    }
}
