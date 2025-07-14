using HIVMedicalSystem.Domain.Abstractions.Entities;

namespace HIVMedicalSystem.Domain.Entities;

public class User: Entity<int>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
    public virtual ICollection<Degree> Degrees { get; set; }
    
    public ICollection<MedicalRecord> MedicalRecordHistory { get; set; }
    public ICollection<MedicalRecord> MedicalRecordsHandled { get; set; }
    public ICollection<TestResult> TestResults { get; set; }
    public ICollection<Appointment> AppointmentsBooked { get; set; }
    public ICollection<Appointment> AppointmentsHandled { get; set; }
}