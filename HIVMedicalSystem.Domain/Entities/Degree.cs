using HIVMedicalSystem.Domain.Abstractions.Entities;

namespace HIVMedicalSystem.Domain.Entities;

public class Degree: Entity<int>
{
    public string DegreeName { get; set; }
}