using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Service.Abstraction;

public interface IARVProtocolService
{
    public Task<List<ARVProtocol>> GetAllARVProtocols();
    public Task<ARVProtocol> GetARVProtocolById(int protocolId);
    public Task AddNewARVProtocol(ARVProtocol arvProtocol);
    public Task UpdateARVProtocol(ARVProtocol arvProtocol);
    public Task DeleteARVProtocol(int arvProtocolId);
}