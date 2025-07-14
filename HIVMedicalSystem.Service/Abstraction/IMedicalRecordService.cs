using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Service.Abstraction;

public interface IMedicalRecordService
{
    public Task<List<MedicalRecord>> GetAllMedicalRecords();
    public Task<List<MedicalRecord>> GetAllMedicalRecordsByDoctorId(int doctorId);
    public Task<List<MedicalRecord>> GetAllMedicalRecordsByCustomerId(int customerId);
    public Task AddNewMedicalRecord(MedicalRecord medicalRecord);
    public Task UpdateMedicalRecord(MedicalRecord medicalRecord);
    public Task DeleteMedicalRecord(int medicalRecordId);
}