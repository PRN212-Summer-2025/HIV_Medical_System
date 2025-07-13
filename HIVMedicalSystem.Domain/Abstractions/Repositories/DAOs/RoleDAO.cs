using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Domain.Abstractions.Repositories.DAOs;

public class RoleDAO: RepositoryBase<Role>
{
    private static RoleDAO _instance;

    public RoleDAO()
    {
    }

    public static RoleDAO Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new RoleDAO();
            }
            return _instance;
        }
    }
}