using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Domain.Abstractions.Repositories.DAOs;

public class TestResultDAO: RepositoryBase<TestResult>
{
    private static TestResultDAO _instance;

    public TestResultDAO()
    {
    }

    public static TestResultDAO Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new TestResultDAO();
            }
            return _instance;
        }
    }
}