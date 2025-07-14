using HIVMedicalSystem.Domain.Abstractions.Repositories.DAOs;
using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Repository.Abstraction;

namespace HIVMedicalSystem.Repository;

public class MedicalRecordRepository: IMedicalRecordRepository
{
    public async Task<List<MedicalRecord>> GetAllMedicalRecords()
    {
        var result = await MedicalRecordDAO.Instance.Get();
        return result.ToList();
    }

    public async Task<List<MedicalRecord>> GetAllMedicalRecordsByDoctorId(int doctorId)
    {
        var result = await MedicalRecordDAO.Instance.Get(filter: item => item.DoctorId == doctorId);
        return result.ToList();
    }

    public async Task<List<MedicalRecord>> GetAllMedicalRecordsByCustomerId(int customerId)
    {
        var result = await MedicalRecordDAO.Instance.Get(filter: item => item.CustomerId == customerId);
        return result.ToList();
    }

    public async Task AddNewMedicalRecord(MedicalRecord medicalRecord)
    {
        MedicalRecordDAO.Instance.Insert(medicalRecord);
    }

    public async  Task UpdateMedicalRecord(MedicalRecord medicalRecord)
    {
        await MedicalRecordDAO.Instance.Update(medicalRecord);
    }

    public async Task DeleteMedicalRecord(int medicalRecordId)
    {
        await MedicalRecordDAO.Instance.Delete(medicalRecordId);
    }
}