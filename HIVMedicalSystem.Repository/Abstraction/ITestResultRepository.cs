using HIVMedicalSystem.Domain.DTOs.Responses;
using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Repository.Abstraction;

public interface ITestResultRepository
{
    public Task<List<TestResultDTO>> GetAllTestResults();
    public Task<List<TestResultDTO>> GetAllTestResultsOfCustomer(int customerId);
    public Task<List<TestResultDTO>> SearchTestResultsByCustomerName(string customerName);
    public Task AddTestResult(TestResult testResult);
    public Task UpdateTestResult(TestResult testResult);
    public Task DeleteTestResult(int testResultId);
}