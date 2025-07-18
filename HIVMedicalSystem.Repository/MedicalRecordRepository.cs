using AutoMapper;
using HIVMedicalSystem.Domain.Abstractions.Repositories.DAOs;
using HIVMedicalSystem.Domain.DTOs.Responses;
using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Repository.Abstraction;

namespace HIVMedicalSystem.Repository;

public class MedicalRecordRepository: IMedicalRecordRepository
{
    private readonly IMapper _mapper;

    public MedicalRecordRepository(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<List<MedicalRecordResponse>> GetAllMedicalRecords()
    {
        var result = await MedicalRecordDAO.Instance.Get();
        return _mapper.Map<List<MedicalRecordResponse>>(result);
    }

    public async Task<List<MedicalRecordResponse>> GetAllMedicalRecordsByDoctorId(int doctorId)
    {
        var result = await MedicalRecordDAO.Instance.Get(filter: item => item.DoctorId == doctorId);
        return _mapper.Map<List<MedicalRecordResponse>>(result);
    }

    public async Task<List<MedicalRecordResponse>> GetAllMedicalRecordsByCustomerId(int customerId)
    {
        var result = await MedicalRecordDAO.Instance.Get(filter: item => item.CustomerId == customerId);
        return _mapper.Map<List<MedicalRecordResponse>>(result);
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