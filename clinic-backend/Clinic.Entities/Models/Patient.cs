namespace Clinic.Entities.Models;

public class Patient : BaseEntity
{
    public Guid UserId { get; set; }

    public DateTime Birthday { get; set; }
    public string Phone { get; set; }
    public string PassportData { get; set; }

    public virtual ICollection<Reception> Receptions { get; set; }
}