using HIVMedicalSystem.Domain.Abstractions.Repositories.DAOs;
using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Repository.Abstraction;

namespace HIVMedicalSystem.Repository;

public class ARVProtocolRepository: IARVProtocolRepository
{
    public async Task<List<ARVProtocol>> GetAllARVProtocols()
    {
        var result = await ARVProtocolDAO.Instance.Get();
        return result.ToList();
    }

    public async Task<ARVProtocol> GetARVProtocolById(int protocolId)
    {
        var result = ARVProtocolDAO.Instance.GetByID(protocolId);
        return result;
    }

    public async Task AddNewARVProtocol(ARVProtocol arvProtocol)
    {
        ARVProtocolDAO.Instance.Insert(arvProtocol);
    }

    public async Task UpdateARVProtocol(ARVProtocol arvProtocol)
    {
        await ARVProtocolDAO.Instance.Update(arvProtocol);
    }

    public async Task DeleteARVProtocol(int arvProtocolId)
    {
        await ARVProtocolDAO.Instance.Delete(arvProtocolId);
    }
}