using Clinic.Shared.Repository;

namespace Clinic.Entities.Models;

public class Reception : BaseEntity
{
    public Guid PatientId { get; set; }
    public virtual Patient Patient { get; set; }

    public Guid ScheduleId { get; set; }
    public virtual Schedule Schedule { get; set; }

    public DateTime ReceptionDateTime { get; set; }
}
