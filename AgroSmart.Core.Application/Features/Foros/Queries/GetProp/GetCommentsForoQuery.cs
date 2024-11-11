using AgroSmart.Core.Application.Dtos.Comments;
using AgroSmart.Core.Application.Dtos.Crop;
using AgroSmart.Core.Application.Dtos.Foro;
using AgroSmart.Core.Application.Enums;
using AgroSmart.Core.Application.Exceptions;
using AgroSmart.Core.Application.Interfaces.Repositories;
using AgroSmart.Core.Application.Interfaces.Services;
using AgroSmart.Core.Application.Wrappers;
using AgroSmart.Core.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Net;

namespace AgroSmart.Core.Application.Features.Foros.Queries.GetProp
{
    public class GetCommentsForoQuery : IRequest<Response<ForoDTO>>
    {
        public int Id { get; set; }
    }

    public class GetCommentsForoQueryHandler : IRequestHandler<GetCommentsForoQuery, Response<ForoDTO>>
    {

        private readonly IGenericRepository<Foro> _repository;
        private readonly IGenericRepository<Comments> _commentRepo;
        private readonly IAccountService _service;
        private readonly IMapper _mapper;

        public GetCommentsForoQueryHandler(IGenericRepository<Foro> repository, IGenericRepository<Comments> commentRepo, IMapper mapper, IAccountService service)
        {
            _repository = repository;
            _commentRepo = commentRepo;
            _mapper = mapper;
            _service = service;
        }

        public async Task<Response<ForoDTO>> Handle(GetCommentsForoQuery request, CancellationToken cancellationToken)
        {

            var foro = await _repository.GetByIdAsync(request.Id);
            if (foro == null)
            {
                throw new ApiException("No hay foro con el id: " + request.Id, (int)HttpStatusCode.NotFound);
            }
            ForoDTO foroDto = new();
            foroDto = _mapper.Map<ForoDTO>(foro);

            var comments = await _commentRepo.GetAllCommentOfForo(request.Id);


            if (!comments.Any())
            {
                foroDto.HasError = true;
                foroDto.Message = "No hay comentarios en este foro";
            }
           
            var users = await _service.GetAllAsync(Roles.Developer.ToString());
            var commentsDto = comments.Where(e=>e.ForoId == request.Id).Select(x => new CommentsDTO
            {
                Content = x.Content,
                ForoId = x.ForoId,
                UserId = x.UserId,
                CommentedBy = users.FirstOrDefault(e=>e.Id == x.UserId).UserName,
                CommentedByImage =  users.FirstOrDefault(e => e.Id == x.UserId).ImageUser == null ? "" : users.FirstOrDefault(e => e.Id == x.UserId).ImageUser
            }).ToList();

            

            foroDto.Comments = commentsDto;

            return new Response<ForoDTO>(foroDto);

        }
    }
}
