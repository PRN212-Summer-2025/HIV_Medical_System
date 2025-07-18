using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Domain.Abstractions.Repositories.DAOs;

public class ARVMedicalRecordDAO: RepositoryBase<ARVMedicalRecord>
{
    private static ARVMedicalRecordDAO _instance;

    public ARVMedicalRecordDAO()
    {
    }

    public static ARVMedicalRecordDAO Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ARVMedicalRecordDAO();
            }
            return _instance;
        }
    }
}