using HIVMedicalSystem.Domain.Abstractions.Entities;

namespace HIVMedicalSystem.Domain.Entities;

public class ARVProtocol: Entity<int>
{
    public string Name { get; set; }
    public string TargetGroup { get; set; }
    public string Line { get; set; }
    public string Description { get; set; }
    
    public ICollection<ARVMedicalRecord> ArvMedicalRecords { get; set; }
}