using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Service.Abstraction;

public interface IUserService
{
    public Task<List<User>> GetAllUsersAsync();
}