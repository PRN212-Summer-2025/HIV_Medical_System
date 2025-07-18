using HIVMedicalSystem.Domain.DTOs.Responses;
using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Repository.Abstraction;

public interface IMedicalRecordRepository
{
    public Task<List<MedicalRecordResponse>> GetAllMedicalRecords();
    public Task<List<MedicalRecordResponse>> GetAllMedicalRecordsByDoctorId(int doctorId);
    public Task<List<MedicalRecordResponse>> GetAllMedicalRecordsByCustomerId(int customerId);
    public Task<MedicalRecordResponse> GetMedicalRecordById(int medicalRecordId);
    public Task AddNewMedicalRecord(MedicalRecord medicalRecord);
    public Task UpdateMedicalRecord(MedicalRecord medicalRecord);
    public Task DeleteMedicalRecord(int medicalRecordId);
}