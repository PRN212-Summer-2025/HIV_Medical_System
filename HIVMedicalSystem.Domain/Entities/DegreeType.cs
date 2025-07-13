using HIVMedicalSystem.Domain.Abstractions.Entities;

namespace HIVMedicalSystem.Domain.Entities;

public class DegreeType: Entity<int>
{
    public string DegreeTypeName { get; set; }
    public ICollection<Degree> Degrees { get; set; }
}