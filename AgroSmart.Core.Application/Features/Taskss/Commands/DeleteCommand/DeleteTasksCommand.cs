using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using MediatR;

namespace AgroSmart.Core.Application.Features.Taskss.Commands.DeleteCommand
{
    public class DeleteTasksCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTasksCommandHandler : IRequestHandler<DeleteTasksCommand, Response<int>>
    {
        private readonly IGenericRepository<Tasks> _repository;

        public DeleteTasksCommandHandler(IGenericRepository<Tasks> repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteTasksCommand request, CancellationToken cancellationToken)
        {
            var tasks = await _repository.GetByIdAsync(request.Id);
            if (tasks == null)
            {
                throw new ApiException("No existe registro con el id: " + request.Id);
            }
            await _repository.DeleteAsync(tasks);
            return new Response<int>(tasks.Id);

        }
    }
}