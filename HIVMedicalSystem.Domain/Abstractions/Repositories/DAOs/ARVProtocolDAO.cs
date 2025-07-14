using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Domain.Abstractions.Repositories.DAOs;

public class ARVProtocolDAO: RepositoryBase<ARVProtocol>
{
    private static ARVProtocolDAO _instance;

    public ARVProtocolDAO()
    {
    }

    public static ARVProtocolDAO Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ARVProtocolDAO();
            }
            return _instance;
        }
    }
}