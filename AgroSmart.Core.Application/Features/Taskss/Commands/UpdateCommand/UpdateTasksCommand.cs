using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Interfaces.Services;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using MediatR;

namespace AgroSmart.Core.Application.Features.Taskss.Commands.UpdateCommand
{
    public class UpdateTasksCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
    }

    public class UpdateTasksCommandHandler : IRequestHandler<UpdateTasksCommand, Response<int>>
    {
        private readonly IGenericRepository<Tasks> _repository;
        private readonly IAccountService _service;

        public UpdateTasksCommandHandler(IGenericRepository<Tasks> repository, IAccountService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task<Response<int>> Handle(UpdateTasksCommand request, CancellationToken cancellationToken)
        {
            var tasks = await _repository.GetByIdAsync(request.Id);
            if (tasks == null)
            {
                throw new ApiException("No existe registro con el id: " + request.Id);
            }
            //Agregar UserId a la migracion...>
            /*var user = await _service.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                throw new ApiException("No existe usuario con el id: " + request.UserId);
            }*/

            tasks.Id = request.Id != null ? request.Id : tasks.Id;
            tasks.Title = request.Title != null ? request.Title : tasks.Title;
            tasks.Description = request.Description != null ? request.Description : tasks.Description;
            tasks.UserId = request.UserId;
            //tasks.UserId = request.UserId != null ? request.UserId : tasks.UserId;

            await _repository.UpdateAsync(tasks);
            return new Response<int>(tasks.Id);
        }
    }
}