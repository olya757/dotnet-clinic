using Microsoft.AspNetCore.Identity;
namespace Clinic.Entities.Models;

public class User : IdentityUser<Guid>, IBaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public Role Role { get; set; }

    #region BaseEntity

    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }

    public bool IsNew()
    {
        return Id == Guid.Empty;
    }

    public void Init()
    {
        Id = Guid.NewGuid();
        CreationTime = DateTime.UtcNow;
        ModificationTime = DateTime.UtcNow;
    }

    #endregion
}


public class UserRole : IdentityRole<Guid>
{ }


