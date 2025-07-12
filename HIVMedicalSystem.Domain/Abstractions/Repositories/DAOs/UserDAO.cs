using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Domain.Abstractions.Repositories.DAOs;

public class UserDAO: RepositoryBase<User>
{
    private static UserDAO _instance;

    public UserDAO()
    {
    }

    public static UserDAO Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UserDAO();
            }
            return _instance;
        }
    }
    
}