using AutoMapper;
using Clinic.WebAPI.Models;
using Clinic.Services.Models;

namespace Clinic.WebAPI.MapperProfile;

public class PresentationProfile : Profile
{
    public PresentationProfile()
    {
        #region  Pages

        CreateMap(typeof(PageModel<>), typeof(PageResponse<>));

        #endregion

        #region Users

        CreateMap<UserModel, UserResponse>();
        CreateMap<UpdateUserRequest, UpdateUserModel>();
        CreateMap<UserPreviewModel, UserPreviewResponse>();

        #endregion
    }
}