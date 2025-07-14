using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Repository.Abstraction;
using HIVMedicalSystem.Service.Abstraction;

namespace HIVMedicalSystem.Service;

public class MedicalRecordService: IMedicalRecordService
{
    private readonly IMedicalRecordRepository _medicalRecordRepository;

    public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository)
    {
        _medicalRecordRepository = medicalRecordRepository;
    }
    
    public async Task<List<MedicalRecord>> GetAllMedicalRecords()
    {
        return await _medicalRecordRepository.GetAllMedicalRecords();
    }

    public async Task<List<MedicalRecord>> GetAllMedicalRecordsByDoctorId(int doctorId)
    {
        return await _medicalRecordRepository.GetAllMedicalRecordsByDoctorId(doctorId);
    }

    public async Task<List<MedicalRecord>> GetAllMedicalRecordsByCustomerId(int customerId)
    {
        return await _medicalRecordRepository.GetAllMedicalRecordsByCustomerId(customerId);
    }

    public async Task AddNewMedicalRecord(MedicalRecord medicalRecord)
    {
        await _medicalRecordRepository.AddNewMedicalRecord(medicalRecord);
    }

    public async Task UpdateMedicalRecord(MedicalRecord medicalRecord)
    {
        await _medicalRecordRepository.UpdateMedicalRecord(medicalRecord);
    }

    public async Task DeleteMedicalRecord(int medicalRecordId)
    {
        await _medicalRecordRepository.DeleteMedicalRecord(medicalRecordId);
    }
}