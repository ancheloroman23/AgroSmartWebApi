using AgroSmart.Core.Application.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AgroSmart.Core.Application.Facade
{
    public class FacadeForImages
    {
        //private readonly IUserService _userService;
        //private readonly IMapper _mapper;

        //public FacadeForImages(IUserService userService,
        //                      IMapper mapper) 
        //{
        //    _userService = userService;
        //    _mapper = mapper;
        //}

        //#region User
        //public async Task<MyProfileViewModel> GetByAgentId(string idAgent) => _mapper.Map<MyProfileViewModel>(await _userService.GetByUserIdAysnc(idAgent));
        //public async Task UpdateAgent(MyProfileViewModel model)
        //{
        //    var saveUser = _mapper.Map<SaveUserViewModel>(model);
        //    await _userService.UpdateAsync(saveUser);
        //}
        //public string UploadFileAgent(IFormFile file, string id, bool isEditMode = false, string imagePath = "")
        //    => _userService.UploadFile(file, id, isEditMode, imagePath);
        //#endregion       
    }
}
