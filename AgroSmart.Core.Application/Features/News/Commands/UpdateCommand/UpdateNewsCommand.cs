
using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Interfaces.Services;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using MediatR;

namespace AgroSmart.Core.Application.Features.News.Commands.UpdateCommand
{
    public class UpdateNewsCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string CompleteDescription { get; set; }
        public int CategoryId { get; set; }        
    }

    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, Response<int>>
    {
        private readonly IGenericRepository<New> _repository;
        private readonly IGenericRepository<Category> _repositoryCategory;
        private readonly IAccountService _service;

        public UpdateNewsCommandHandler(IGenericRepository<New> repository, IGenericRepository<Category> repositoryCategory, IAccountService service)
        {
            _repository = repository;
            _repositoryCategory = repositoryCategory;
            _service = service;        
        }

        public async Task<Response<int>> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            var news = await _repository.GetByIdAsync(request.Id);
            if (news == null)
            {
                throw new ApiException("No existe registro con el id: " + request.Id);
            }            
            var category = await _repositoryCategory.GetByIdAsync(request.CategoryId);
            if (category == null)
            {
                throw new ApiException("No existe Categoria con el id: " + request.CategoryId);
            }

            news.Id = request.Id != null ? request.Id : news.Id;
            news.Title = request.Title != null ? request.Title : news.Title;
            news.Summary = request.Summary != null ? request.Summary : news.Summary;
            news.CompleteDescription = request.CompleteDescription != null ? request.CompleteDescription : news.CompleteDescription;
            news.CategoryId = request.CategoryId != null ? request.CategoryId : news.CategoryId;

            await _repository.UpdateAsync(news);
            return new Response<int>(news.Id);
        }
    }
}