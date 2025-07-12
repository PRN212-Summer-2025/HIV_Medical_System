using HIVMedicalSystem.Domain.Abstractions.Repositories.DAOs;
using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Repository.Abstraction;

namespace HIVMedicalSystem.Repository;

public class UserRepository: IUserRepository
{
    public async Task<List<User>> GetAllUsersAsync()
    {
        var result = await UserDAO.Instance.Get();
        return result.ToList();
    }
}