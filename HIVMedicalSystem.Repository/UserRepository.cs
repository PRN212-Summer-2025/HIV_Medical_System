using AutoMapper;
using HIVMedicalSystem.Domain.Abstractions.Repositories.DAOs;
using HIVMedicalSystem.Domain.DTOs.Responses;
using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Repository.Abstraction;

namespace HIVMedicalSystem.Repository;

public class UserRepository: IUserRepository
{
    private readonly IMapper _mapper;

    public UserRepository(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<List<UserDTO>> GetAllUsersAsync()
    {
        var result = await UserDAO.Instance.Get(null, null, "Role");
        return _mapper.Map<List<UserDTO>>(result);
    }

    public async Task<List<UserDTO>> GetAllCustomersAsync()
    {
        var result = await UserDAO.Instance.Get(filter: filter => filter.RoleId == 3, null, "Role");
        return _mapper.Map<List<UserDTO>>(result);
    }

    public async Task<List<UserDTO>> GetAllDoctorsAsync()
    {
        var result = await UserDAO.Instance.Get(filter: filter => filter.RoleId == 4, null, "Role");
        return _mapper.Map<List<UserDTO>>(result);
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        var result = await UserDAO.Instance.Get(filter: filter => filter.Email == email);
        return result.FirstOrDefault();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        var result = await UserDAO.Instance.Get(filter: filter => filter.Id == id);
        return result.FirstOrDefault();
    }

    public async Task<int> Authentication(string email, string password)
    {
        var result = await UserDAO.Instance.Get(
            filter: item => item.Email.Equals(email) && item.Password.Equals(password),
            orderBy: item => item.OrderBy(user => user.Id),
            includeProperties: "Degrees,Role"
        );
        if (!result.Any()) return 0;
        return result.FirstOrDefault()!.RoleId; 
    }

    public async Task<List<UserDTO>> SearchUsers(string search)
    {
        var result = await UserDAO.Instance.Get(item => item.FullName.Contains(search));
        return _mapper.Map<List<UserDTO>>(result);
    }
}