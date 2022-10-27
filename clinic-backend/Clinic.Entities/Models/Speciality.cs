
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations.Schema;
using Clinic.Shared.Repository;

namespace Clinic.Entities.Models;

public class Speciality : BaseEntity
{
    public string Name { get; set; }

    public Guid? ParentSpecialityId { get; set; }
    public virtual Speciality ParentSpeciality { get; set; }

    public virtual ICollection<Speciality> ChildrenSpecialities { get; set; }
    public virtual ICollection<DoctorSpeciality> Doctors { get; set; }
    public virtual ICollection<Schedule> Schedules { get; set; }
}