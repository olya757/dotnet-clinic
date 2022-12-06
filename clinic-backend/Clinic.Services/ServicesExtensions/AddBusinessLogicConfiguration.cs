using Clinic.Services.Abstract;
using Clinic.Services.Implementation;
using Clinic.Services.MapperProfile;
using Microsoft.Extensions.DependencyInjection;

namespace Clinic.Services;

public static partial class ServicesExtensions
{
    public static void AddBusinessLogicConfiguration(this IServiceCollection services)
    {
        //mapper
        services.AddAutoMapper(typeof(ServicesProfile));

        //services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
    }
}