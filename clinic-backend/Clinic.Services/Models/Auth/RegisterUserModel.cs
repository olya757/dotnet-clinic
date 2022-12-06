using Clinic.Entities.Models;

namespace Clinic.Services.Models;

public class RegisterUserModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronimyc { get; set; }
    public Role Role { get; set; }
}