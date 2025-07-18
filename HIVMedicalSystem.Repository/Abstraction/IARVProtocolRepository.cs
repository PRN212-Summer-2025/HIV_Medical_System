using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Repository.Abstraction;

public interface IARVProtocolRepository
{
    public Task<List<ARVProtocol>> GetAllARVProtocols();
    public Task<ARVProtocol> GetARVProtocolById(int protocolId);
    public Task AddNewARVProtocol(ARVProtocol arvProtocol);
    public Task UpdateARVProtocol(ARVProtocol arvProtocol);
    public Task DeleteARVProtocol(int arvProtocolId);
}