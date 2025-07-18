using HIVMedicalSystem.Domain.Abstractions.Entities;

namespace HIVMedicalSystem.Domain.Entities;

public class Appointment: Entity<int>
{
    public int CustomerId { get; set; }
    public virtual User Customer { get; set; }
    
    public int DoctorId { get; set; }
    public virtual User Doctor { get; set; }
    
    public DateTime AppointmentDateTime { get; set; }
    public int Status { get; set; } = 0;
    public bool IsAnonymous { get; set; } = false;
}