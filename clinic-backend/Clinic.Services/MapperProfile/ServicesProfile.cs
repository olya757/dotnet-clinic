using AutoMapper;
using Clinic.Entities.Models;
using Clinic.Services.Models;

namespace Clinic.Services.MapperProfile;

public class ServicesProfile : Profile
{
    public ServicesProfile()
    {
        #region Users

        CreateMap<User, UserModel>().ReverseMap();
        CreateMap<User, UserPreviewModel>()
            .ForMember(x => x.FullName, y => y.MapFrom(u => $"{u.LastName} {u.FirstName} {u.Patronymic}"));

        #endregion
    }
}