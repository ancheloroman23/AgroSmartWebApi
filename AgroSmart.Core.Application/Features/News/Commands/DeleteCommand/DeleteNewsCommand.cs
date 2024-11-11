using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using MediatR;

namespace AgroSmart.Core.Application.Features.News.Commands.DeleteCommand
{
    public class DeleteNewsCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, Response<int>>
    {
        private readonly IGenericRepository<New> _repository;

        public DeleteNewsCommandHandler(IGenericRepository<New> repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            var news = await _repository.GetByIdAsync(request.Id);
            if (news == null)
            {
                throw new ApiException("No existe registro con el id: " + request.Id);
            }
            await _repository.DeleteAsync(news);
            return new Response<int>(news.Id);
        }
    }
}