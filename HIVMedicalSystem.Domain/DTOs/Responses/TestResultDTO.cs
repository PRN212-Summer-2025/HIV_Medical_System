namespace HIVMedicalSystem.Domain.DTOs.Responses;

public class TestResultDTO
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string TestDate { get; set; }
    public int CD4Count { get; set; }
    public int ViralLoad { get; set; }
    public decimal ALT { get; set; }
    public decimal AST { get; set; }
    public decimal Creatine { get; set; }
    public string Notes { get; set; }
}