using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Domain.Abstractions.Repositories.DAOs;

public class DegreeTypeDAO: RepositoryBase<DegreeType>
{
    private static DegreeTypeDAO _instance;

    public DegreeTypeDAO()
    {
    }

    public static DegreeTypeDAO Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DegreeTypeDAO();
            }
            return _instance;
        }
    }
}