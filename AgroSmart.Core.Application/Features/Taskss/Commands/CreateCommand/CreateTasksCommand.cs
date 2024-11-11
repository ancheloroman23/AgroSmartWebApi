using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Interfaces.Services;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AgroSmart.Core.Application.Features.Taskss.Commands.CreateCommand
{
    public class CreateTasksCommand : IRequest<Response<int>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
    }

    public class CreateTasksCommandHandler : IRequestHandler<CreateTasksCommand, Response<int>>
    {
        private readonly IGenericRepository<Tasks> _repository;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public CreateTasksCommandHandler(IGenericRepository<Tasks> repository, IAccountService accountService, IMapper mapper)
        {
            _repository = repository;
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateTasksCommand request, CancellationToken cancellationToken)
        {

            //Vengo ahora, hay que hacer la migracion....>
            /*var user = await _accountService.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                throw new ApiException("No hay user con este id");
            }*/

            var tasks = _mapper.Map<Tasks>(request);

            var tasksAdded = _repository.AddAsync(tasks);

            if (tasksAdded == null)
            {
                throw new ApiException("Hubo un error agregando los datos");
            }

            return new Response<int>(tasksAdded.Id);

        }
    }
}