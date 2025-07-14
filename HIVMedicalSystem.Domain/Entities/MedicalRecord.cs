using HIVMedicalSystem.Domain.Abstractions.Entities;

namespace HIVMedicalSystem.Domain.Entities;

public class MedicalRecord: Entity<int>
{
    public DateTime DiagnosisDate { get; set; }
    public string TreatmentNotes { get; set; }
    
    public int CustomerId { get; set; }
    public virtual User Customer { get; set; }
    
    public int DoctorId { get; set; }
    public virtual User Doctor { get; set; }
    
    public ICollection<ARVMedicalRecord> ARVMedicalRecords { get; set; }
}