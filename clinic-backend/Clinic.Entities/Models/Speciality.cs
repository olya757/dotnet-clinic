namespace Clinic.Entities.Models;

public class Speciality : BaseEntity
{
    public string Name { get; set; }

    public Guid? ParentSpecialityId { get; set; }
    public virtual Speciality? ParentSpeciality { get; set; }

    public virtual ICollection<Speciality> ChildrenSpecialities { get; set; }
    public virtual ICollection<DoctorSpeciality> Doctors { get; set; }
    public virtual ICollection<Schedule> Schedules { get; set; }
}