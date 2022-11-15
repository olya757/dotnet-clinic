using Clinic.Entities.Models;

namespace Clinic.Services.Models;

public class UserModel : BaseModel
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public Role Role { get; set; }
}