using HIVMedicalSystem.Domain.DTOs.Responses;
using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Repository.Abstraction;
using HIVMedicalSystem.Service.Abstraction;

namespace HIVMedicalSystem.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<List<UserDTO>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }

    public async Task<List<UserDTO>> GetAllCustomersAsync()
    {
        return await _userRepository.GetAllCustomersAsync();
    }

    public async Task<List<UserDTO>> GetAllDoctorsAsync()
    {
        return await _userRepository.GetAllDoctorsAsync();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _userRepository.GetUserByIdAsync(id);
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _userRepository.GetUserByEmailAsync(email);
    }

    public async Task<int> Authentication(string email, string password)
    {
        return await _userRepository.Authentication(email, password);
    }

    public async Task<List<UserDTO>> SearchUsers(string search)
    {
        return await _userRepository.SearchUsers(search);
    }
}