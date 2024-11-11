using AgroSmart.Core.Application.Dtos.Crop;
using AgroSmart.Core.Application.Dtos.Tasks;
using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Features.Crops.Queries.GetByIdQuery;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AgroSmart.Core.Application.Features.Taskss.Queries.GetByIdQuery
{
    public class GetTasksByIdQuery : IRequest<Response<TasksDTO>>
    {
        public int Id { get; set; }
    }

    public class GetTasksByIdQueryHandler : IRequestHandler<GetTasksByIdQuery, Response<TasksDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Tasks> _repository;

        public GetTasksByIdQueryHandler(IMapper mapper, IGenericRepository<Tasks> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<TasksDTO>> Handle(GetTasksByIdQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _repository.GetByIdAsync(request.Id);
            if (tasks == null)
            {
                throw new ApiException("No hay cultivos con el id: " + request.Id);
            }

            var tasksDto = _mapper.Map<TasksDTO>(request);
            return new Response<TasksDTO>(tasksDto);
        }
    }
}