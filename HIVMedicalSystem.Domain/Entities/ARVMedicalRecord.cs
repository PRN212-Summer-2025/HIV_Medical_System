using HIVMedicalSystem.Domain.Abstractions.Entities;

namespace HIVMedicalSystem.Domain.Entities;

public class ARVMedicalRecord: Entity<int>
{
    public int RecordId { get; set; }
    public virtual MedicalRecord MedicalRecord { get; set; }
    
    public int ARVProtocolId { get; set; }
    public virtual ARVProtocol ARVProtocol { get; set; }
    
}