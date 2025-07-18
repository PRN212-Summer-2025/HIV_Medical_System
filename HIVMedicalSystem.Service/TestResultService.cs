﻿using HIVMedicalSystem.Domain.DTOs.Responses;
using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Repository.Abstraction;
using HIVMedicalSystem.Service.Abstraction;

namespace HIVMedicalSystem.Service;

public class TestResultService: ITestResultService
{
    private readonly ITestResultRepository _testResultRepository;

    public TestResultService(ITestResultRepository testResultRepository)
    {
        _testResultRepository = testResultRepository;
    }
    
    public async Task<List<TestResultDTO>> GetAllTestResults()
    {
        return await _testResultRepository.GetAllTestResults();
    }

    public async Task<List<TestResultDTO>> GetAllTestResultsByCustomerId(int customerId)
    {
        return await _testResultRepository.GetAllTestResultsOfCustomer(customerId);
    }

    public async Task<List<TestResultDTO>> SearchTestResultsByCustomerName(string customerName)
    {
        return await _testResultRepository.SearchTestResultsByCustomerName(customerName);
    }

    public async Task AddNewTestResult(TestResult testResult)
    {
        await _testResultRepository.AddTestResult(testResult);
    }

    public async Task UpdateTestResult(TestResult testResult)
    {
        await _testResultRepository.UpdateTestResult(testResult);
    }

    public async Task DeleteTestResult(int testResultId)
    {
        await _testResultRepository.DeleteTestResult(testResultId);
    }
}