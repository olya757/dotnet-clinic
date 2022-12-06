using Clinic.Services.Models;
using IdentityModel.Client;

namespace Clinic.Services.Abstract;

public interface IAuthService
{
    Task<UserModel> RegisterUser(RegisterUserModel model);
    Task<TokenResponse> LoginUser(LoginUserModel model);
}



