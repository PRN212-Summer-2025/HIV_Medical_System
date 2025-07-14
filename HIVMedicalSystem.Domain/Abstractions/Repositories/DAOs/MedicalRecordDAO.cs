using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Domain.Abstractions.Repositories.DAOs;

public class MedicalRecordDAO: RepositoryBase<MedicalRecord>
{
    private static MedicalRecordDAO _instance;

    public MedicalRecordDAO()
    {
    }

    public static MedicalRecordDAO Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MedicalRecordDAO();
            }
            return _instance;
        }
    }
}