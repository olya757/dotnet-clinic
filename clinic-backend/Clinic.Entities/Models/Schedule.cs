namespace Clinic.Entities.Models;

public class Schedule : BaseEntity
{
    public virtual Guid DoctorId { get; set; }
    public virtual Doctor Doctor { get; set; }

    public Guid SpecialityId { get; set; }
    public virtual Speciality Speciality { get; set; }

    public DateTime StartOfReception { get; set; }
    public DateTime EndOfReception { get; set; }

    public TimeSpan ReceptionDuration { get; set; }

    public virtual ICollection<Reception> Receptions { get; set; }
}