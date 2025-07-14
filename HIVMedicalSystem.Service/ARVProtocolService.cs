using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Repository.Abstraction;
using HIVMedicalSystem.Service.Abstraction;

namespace HIVMedicalSystem.Service;

public class ARVProtocolService: IARVProtocolService
{
    private readonly IARVProtocolRepository _arvProtocolRepository;

    public ARVProtocolService(IARVProtocolRepository arvProtocolRepository)
    {
        _arvProtocolRepository = arvProtocolRepository;
    }
    
    public async Task<List<ARVProtocol>> GetAllARVProtocols()
    {
        return await  _arvProtocolRepository.GetAllARVProtocols();
    }

    public async Task AddNewARVProtocol(ARVProtocol arvProtocol)
    {
        await _arvProtocolRepository.AddNewARVProtocol(arvProtocol);
    }

    public async Task UpdateARVProtocol(ARVProtocol arvProtocol)
    {
        await  _arvProtocolRepository.UpdateARVProtocol(arvProtocol);
    }

    public async Task DeleteARVProtocol(int arvProtocolId)
    {
        await _arvProtocolRepository.DeleteARVProtocol(arvProtocolId);
    }
}