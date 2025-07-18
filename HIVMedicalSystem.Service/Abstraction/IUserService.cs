using HIVMedicalSystem.Domain.DTOs.Responses;
using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Service.Abstraction;

public interface IUserService
{
    public Task<List<UserDTO>> GetAllUsersAsync();
    public Task<List<UserDTO>> GetAllCustomersAsync();
    public Task<List<UserDTO>> GetAllDoctorsAsync();
    public Task<User> GetUserByIdAsync(int id);
    public Task<User> GetUserByEmailAsync(string email);
    public Task<int> Authentication(string email, string password);
    public Task<List<UserDTO>> SearchUsers(string search);
}