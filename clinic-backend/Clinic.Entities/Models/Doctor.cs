using Clinic.Shared.Repository;

namespace Clinic.Entities.Models;
public class Doctor : BaseEntity
{
    public Guid UserId { get; set; }

    public virtual ICollection<DoctorSpeciality> Specialities { get; set; }
    public virtual ICollection<Schedule> Schedules { get; set; }
}
