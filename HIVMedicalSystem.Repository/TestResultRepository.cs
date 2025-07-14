using HIVMedicalSystem.Domain.Abstractions.Repositories.DAOs;
using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Repository.Abstraction;

namespace HIVMedicalSystem.Repository;

public class TestResultRepository: ITestResultRepository
{
    public async Task<List<TestResult>> GetAllTestResults()
    {
        var result = await TestResultDAO.Instance.Get();
        return result.ToList();
    }

    public async Task<List<TestResult>> GetAllTestResultsOfCustomer(int customerId)
    {
        var result = await TestResultDAO.Instance.Get(filter: filter => filter.UserId == customerId);
        return result.ToList();
    }

    public async Task AddTestResult(TestResult testResult)
    {
        TestResultDAO.Instance.Insert(testResult);
    }

    public async Task UpdateTestResult(TestResult testResult)
    {
        await TestResultDAO.Instance.Update(testResult);
    }

    public async Task DeleteTestResult(int testResultId)
    {
        await TestResultDAO.Instance.Delete(testResultId);
    }
}