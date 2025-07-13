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

    public async Task<int> Authentication(string email, string password)
    {
        var result = await UserDAO.Instance.Get(
            filter: item => item.Email.Equals(email) && item.Password.Equals(password),
            orderBy: item => item.OrderBy(user => user.Id),
            includeProperties: "Degrees,Role"
        );
        return result.FirstOrDefault()!.RoleId; 
    }
}