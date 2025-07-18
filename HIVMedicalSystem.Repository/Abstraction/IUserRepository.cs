using HIVMedicalSystem.Domain.DTOs.Responses;
using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Repository.Abstraction;

public interface IUserRepository
{
    public Task<List<UserDTO>> GetAllUsersAsync();
    public Task<List<UserDTO>> GetAllCustomersAsync();
    public Task<List<UserDTO>> GetAllDoctorsAsync();
    public Task<User> GetUserByEmailAsync(string email);
    public Task<User> GetUserByIdAsync(int id);
    public Task<int> Authentication(string email, string password);
    public Task<List<UserDTO>> SearchUsers(string search);
}