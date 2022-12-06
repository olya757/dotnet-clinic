using AutoMapper;
using Clinic.Entities.Models;
using Clinic.Services.Models;

namespace Clinic.Services.MapperProfile;

public class ServicesProfile : Profile
{
    public ServicesProfile()
    {
        #region Users

        CreateMap<User, UserModel>()
            .ForMember(x => x.Email, y => y.MapFrom(u => u.Email))
            .ForMember(x => x.FirstName, y => y.MapFrom(u => u.FirstName))
            .ForMember(x => x.LastName, y => y.MapFrom(u => u.LastName))
            .ForMember(x => x.Patronymic, y => y.MapFrom(u => u.Patronymic))
            .ForMember(x => x.Role, y => y.MapFrom(u => u.Role))
            .ForMember(x => x.Id, y => y.MapFrom(u => u.Id))
            .ForMember(x => x.CreationTime, y => y.MapFrom(u => u.CreationTime))
            .ForMember(x => x.ModificationTime, y => y.MapFrom(u => u.ModificationTime));

        CreateMap<User, UserPreviewModel>()
            .ForMember(x => x.FullName, y => y.MapFrom(u => $"{u.LastName} {u.FirstName} {u.Patronymic}"))
            .ForMember(x => x.Id, y => y.MapFrom(u => u.Id))
            .ForMember(x => x.Email, y => y.MapFrom(u => u.Email));

        #endregion
    }
}