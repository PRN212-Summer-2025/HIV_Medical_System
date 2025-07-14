using HIVMedicalSystem.Domain.Abstractions.Entities;

namespace HIVMedicalSystem.Domain.Entities;

public class TestResult: Entity<int>
{
    public DateTime TestDate { get; set; }
    public int CD4Count { get; set; }
    public int ViralLoad { get; set; }
    public decimal ALT { get; set; }
    public decimal AST { get; set; }
    public decimal Creatine { get; set; }
    public string Notes { get; set; }
    
    public int UserId { get; set; }
    public virtual User User { get; set; }
}