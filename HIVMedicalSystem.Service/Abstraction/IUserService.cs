using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Service.Abstraction;

public interface IUserService
{
    public Task<List<User>> GetAllUsersAsync();
    public Task<int> Authentication(string email, string password);
    public Task<List<User>> SearchUsers(string search);
}