using HIVMedicalSystem.Domain.DTOs.Responses;
using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Service.Abstraction;

public interface IMedicalRecordService
{
    public Task<List<MedicalRecordResponse>> GetAllMedicalRecords();
    public Task<List<MedicalRecordResponse>> GetAllMedicalRecordsByDoctorId(int doctorId);
    public Task<List<MedicalRecordResponse>> GetAllMedicalRecordsByCustomerId(int customerId);
    public Task AddNewMedicalRecord(MedicalRecord medicalRecord);
    public Task UpdateMedicalRecord(MedicalRecord medicalRecord);
    public Task DeleteMedicalRecord(int medicalRecordId);
}