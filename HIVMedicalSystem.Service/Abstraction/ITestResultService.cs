using HIVMedicalSystem.Domain.DTOs.Responses;
using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Service.Abstraction;

public interface ITestResultService
{
    public Task<List<TestResultDTO>> GetAllTestResults();
    public Task<List<TestResultDTO>> GetAllTestResultsByCustomerId(int customerId);
    public Task<List<TestResultDTO>> SearchTestResultsByCustomerName(string customerName);
    public Task AddNewTestResult(TestResult testResult);
    public Task UpdateTestResult(TestResult testResult);
    public Task DeleteTestResult(int testResultId);
}