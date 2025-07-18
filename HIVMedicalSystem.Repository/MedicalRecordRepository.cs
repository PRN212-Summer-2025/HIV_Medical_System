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
        var result = await MedicalRecordDAO.Instance.Get(null, null, "ARVMedicalRecords,Doctor,Customer");
        var response = _mapper.Map<List<MedicalRecordResponse>>(result);
        for (var i = 0; i < response.Count; i++)
        {
            response[i].ARVProtocols = new List<ARVProtocol>();
            foreach (var item in result.ToList()[i].ARVMedicalRecords)
            {
                var protocol = ARVProtocolDAO.Instance.GetByID(item.ARVProtocolId);
                response[i].ARVProtocols.Add(protocol);
            }
        }
        return response;
    }

    public async Task<List<MedicalRecordResponse>> GetAllMedicalRecordsByDoctorId(int doctorId)
    {
        var result = await MedicalRecordDAO.Instance.Get(filter: item => item.DoctorId == doctorId);
        return _mapper.Map<List<MedicalRecordResponse>>(result);
    }

    public async Task<List<MedicalRecordResponse>> GetAllMedicalRecordsByCustomerId(int customerId)
    {
        var result = await MedicalRecordDAO.Instance.Get(filter: item => item.CustomerId == customerId, null, "ARVMedicalRecords,Doctor,Customer");
        var response = _mapper.Map<List<MedicalRecordResponse>>(result);
        for (var i = 0; i < response.Count; i++)
        {
            response[i].ARVProtocols = new List<ARVProtocol>();
            foreach (var item in result.ToList()[i].ARVMedicalRecords)
            {
                var protocol = ARVProtocolDAO.Instance.GetByID(item.ARVProtocolId);
                response[i].ARVProtocols.Add(protocol);
            }
        }
        return response;
    }

    public async Task<MedicalRecordResponse> GetMedicalRecordById(int medicalRecordId)
    {
        var list = await MedicalRecordDAO.Instance.Get(filter => filter.Id == medicalRecordId, null, "ARVMedicalRecords,Customer,Doctor");
        var result = list.FirstOrDefault();
        var response = _mapper.Map<MedicalRecordResponse>(result);
        response.ARVProtocols = new List<ARVProtocol>();
        foreach (var item in result.ARVMedicalRecords)
        {
            var protocol = ARVProtocolDAO.Instance.GetByID(item.ARVProtocolId);
            response.ARVProtocols.Add(protocol);
        }
        return response;
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