using AgroSmart.Core.Application.Dtos.Category;
using AgroSmart.Core.Application.Dtos.Comments;
using AgroSmart.Core.Application.Dtos.Crop;
using AgroSmart.Core.Application.Dtos.Foro;
using AgroSmart.Core.Application.Dtos.New;
using AgroSmart.Core.Application.Dtos.Tasks;
using AgroSmart.Core.Application.Features.Commentss.Commands.CreateCommand;
using AgroSmart.Core.Application.Features.Crops.Commands.CreateCommand;
using AgroSmart.Core.Application.Features.Crops.Queries.GetByIdQuery;
using AgroSmart.Core.Application.Features.Foros.Commands.CreateCommand;
using AgroSmart.Core.Application.Features.News.Commands.CreateCommand;
using AgroSmart.Core.Application.Features.Taskss.Commands.CreateCommand;
using AgroSmart.Core.Domain.Entities;
using AutoMapper;

namespace AgroSmart.Core.Application.Mappings
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile()
        {

            #region Category
            CreateMap<CategoryDTO, Category>()
                .ReverseMap();


            #endregion

            #region Comments
            CreateMap<CommentsDTO, Comments>()
                .ReverseMap()
                .ForMember(e => e.CommentedBy, obj => obj.Ignore())
                .ForMember(e => e.CommentedByImage, obj => obj.Ignore());


            CreateMap<CreateCommentsCommand, Comments>()
                .ReverseMap();

            #endregion

            #region News
            CreateMap<NewDTO, New>()
                .ReverseMap();

            CreateMap<CreateNewsCommand, New>()
                .ReverseMap();
            #endregion

            #region Tasks
            CreateMap<TasksDTO, Tasks>()
                .ReverseMap();

            CreateMap<CreateTasksCommand, Tasks>()
                .ReverseMap();
            #endregion

            #region Foro
            CreateMap<Foro, ForoDTO>()
                .ReverseMap();

            CreateMap<CreateForoCommand, Foro>()
                .ReverseMap();
            #endregion 

            #region Crop
            CreateMap<Crop, CropDTO>()
                .ReverseMap();

            CreateMap<CreateCropCommand, Crop>()
                .ReverseMap();            
            #endregion 
        }
    }
}
