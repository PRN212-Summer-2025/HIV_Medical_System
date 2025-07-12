using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Repository.Abstraction;

public interface IUserRepository
{
    public Task<List<User>> GetAllUsersAsync();
}