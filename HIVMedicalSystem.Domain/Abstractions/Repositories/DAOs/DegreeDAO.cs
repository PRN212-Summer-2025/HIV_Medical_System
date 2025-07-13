using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Domain.Abstractions.Repositories.DAOs;

public class DegreeDAO: RepositoryBase<Degree>
{
    private static DegreeDAO _instance;

    public DegreeDAO()
    {
    }

    public static DegreeDAO Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DegreeDAO();
            }
            return _instance;
        }
    }
}