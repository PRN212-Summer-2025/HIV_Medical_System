using HIVMedicalSystem.Domain.Abstractions.Entities;

namespace HIVMedicalSystem.Domain.Entities;

public class User: Entity<int>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
}