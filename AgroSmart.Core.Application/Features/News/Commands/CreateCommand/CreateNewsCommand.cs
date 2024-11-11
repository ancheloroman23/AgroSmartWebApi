using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Interfaces.Services;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Net;

namespace AgroSmart.Core.Application.Features.News.Commands.CreateCommand
{
    public class CreateNewsCommand : IRequest<Response<int>>
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string CompleteDescription { get; set; }
        public int CategoryId { get; set; }        
    }

    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, Response<int>>
    {
        private readonly IGenericRepository<New> _repository;
        private readonly IGenericRepository<Category> _repositoryCategory;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public CreateNewsCommandHandler(IGenericRepository<New> repository, IGenericRepository<Category> repositoryCategory, IAccountService accountService, IMapper mapper)
        {
            _repository = repository;
            _repositoryCategory = repositoryCategory;
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            var category = await _repositoryCategory.GetByIdAsync(request.CategoryId);
            if (category == null)
            {
                throw new ApiException("No hay una categoria con este id", (int)HttpStatusCode.NotFound);
            }

            var news = _mapper.Map<New>(request);

            var newsAdded = _repository.AddAsync(news);

            if (newsAdded == null)
            {
                throw new ApiException("Hubo un error agregando los datos");
            }

            return new Response<int>(newsAdded.Id);

        }
    }
}