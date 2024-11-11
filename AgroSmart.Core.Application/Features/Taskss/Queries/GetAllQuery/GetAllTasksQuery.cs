using AgroSmart.Core.Application.Dtos.Tasks;
using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AgroSmart.Core.Application.Features.Taskss.Queries.GetAllQuery
{
    public class GetAllTasksQuery : IRequest<Response<List<TasksDTO>>>
    {
        public string UserId { get; set; }
    }

    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, Response<List<TasksDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Tasks> _repository;

        public GetAllTasksQueryHandler(IMapper mapper, IGenericRepository<Tasks> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }



        async Task<Response<List<TasksDTO>>> IRequestHandler<GetAllTasksQuery, Response<List<TasksDTO>>>.Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _repository.ListAsync();
            if (!tasks.Any())
            {
                throw new ApiException("No hay ningun tarea registrada");
            }

            var tasksDto = _mapper.Map<List<TasksDTO>>(tasks);

            var taskOfUser = tasksDto.Where(e => e.UserId == request.UserId).ToList();
            return new Response<List<TasksDTO>>(taskOfUser);
        }
    }
}