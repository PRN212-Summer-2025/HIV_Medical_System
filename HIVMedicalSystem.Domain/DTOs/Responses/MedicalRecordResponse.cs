using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Domain.DTOs.Responses;

public class MedicalRecordResponse
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string DoctorName { get; set; }
    public string TreatmentNotes { get; set; }
    public string DiagnosisDate { get; set; }
    
}