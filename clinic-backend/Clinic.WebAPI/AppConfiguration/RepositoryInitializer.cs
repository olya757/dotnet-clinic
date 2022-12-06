using System;
using Clinic.Entities.Models;
using Clinic.Repository;
using Clinic.Services.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Clinic.WebAPI.AppConfiguration;

public static class RepositoryInitializer
{
    public const string MASTER_ADMIN_EMAIL = "master@mail.ru";
    public const string MASTER_ADMIN_PASSWORD = "password";

    private static async Task CreateGlobalAdmin(IAuthService authService)
    {
        await authService.RegisterUser(new Services.Models.RegisterUserModel()
        {
            Email = MASTER_ADMIN_EMAIL,
            Password = MASTER_ADMIN_PASSWORD,
            Role = Entities.Models.Role.Admin
        });
    }

    public static async Task InitializeRepository(IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        {
            var userManager = (UserManager<User>)scope.ServiceProvider.GetRequiredService(typeof(UserManager<User>));
            var user = await userManager.FindByEmailAsync(MASTER_ADMIN_EMAIL);
            if (user == null)
            {
                var authService = (IAuthService)scope.ServiceProvider.GetRequiredService(typeof(IAuthService));
                await CreateGlobalAdmin(authService);
            }
        }
    }
}