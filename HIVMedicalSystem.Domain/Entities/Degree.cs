using HIVMedicalSystem.Domain.Abstractions.Entities;

namespace HIVMedicalSystem.Domain.Entities;

public class Degree: Entity<int>
{
    public string DegreeName { get; set; }
    public int DegreeTypeId { get; set; }
    public virtual DegreeType DegreeType { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
}