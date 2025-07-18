using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Repository.Abstraction;

public interface ITestResultRepository
{
    public Task<List<TestResult>> GetAllTestResults();
    public Task<List<TestResult>> GetAllTestResultsOfCustomer(int customerId);
    public Task AddTestResult(TestResult testResult);
    public Task UpdateTestResult(TestResult testResult);
    public Task DeleteTestResult(int testResultId);
}