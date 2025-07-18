using AutoMapper;
using HIVMedicalSystem.Domain.Abstractions.Repositories.DAOs;
using HIVMedicalSystem.Domain.DTOs.Responses;
using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Repository.Abstraction;

namespace HIVMedicalSystem.Repository;

public class TestResultRepository: ITestResultRepository
{
    private readonly IMapper _mapper;

    public TestResultRepository(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<List<TestResultDTO>> GetAllTestResults()
    {
        var result = await TestResultDAO.Instance.Get(null, order => order.OrderByDescending(item => item.Id), "User");
        return _mapper.Map<List<TestResultDTO>>(result);
    }

    public async Task<List<TestResultDTO>> GetAllTestResultsOfCustomer(int customerId)
    {
        var result = await TestResultDAO.Instance.Get(filter: filter => filter.UserId == customerId, order => order.OrderByDescending(item => item.Id), "User");
        return _mapper.Map<List<TestResultDTO>>(result);
    }

    public async Task<List<TestResultDTO>> SearchTestResultsByCustomerName(string customerName)
    {
        var list = await TestResultDAO.Instance.Get(filter => filter.User.FullName.Contains(customerName),
            order => order.OrderByDescending(item => item.Id), "User");
        return _mapper.Map<List<TestResultDTO>>(list);
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