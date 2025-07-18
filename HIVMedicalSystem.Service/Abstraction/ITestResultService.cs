using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Service.Abstraction;

public interface ITestResultService
{
    public Task<List<TestResult>> GetAllTestResults();
    public Task<List<TestResult>> GetAllTestResultsByCustomerId(int customerId);
    public Task AddNewTestResult(TestResult testResult);
    public Task UpdateTestResult(TestResult testResult);
    public Task DeleteTestResult(int testResultId);
}