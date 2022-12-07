using Clinic.Entities.Models;
using Clinic.Repository;
using Clinic.Services.Abstract;
using NUnit.Framework;

namespace Clinic.Test;

[TestFixture]
public partial class UserTests : UnitTest
{
    private  IAuthService authService;
    private  IUserService userService;
    private  IRepository<User> userRepository;
    
    public async override Task OneTimeSetUp()
    {
        await base.OneTimeSetUp();
        authService = services.Get<IAuthService>();
        userService = services.Get<IUserService>();
        userRepository = services.Get<IRepository<User>>();
    }

    protected async override Task ClearDb()
    {
        var userRepository = services.Get<IRepository<User>>();
        var users = userRepository.GetAll().ToList();
        foreach(var user in users)
        {
            userRepository.Delete(user);
        }
    }

}