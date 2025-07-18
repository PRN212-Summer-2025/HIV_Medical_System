using System.Windows;
using System.Windows.Controls;
using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Service.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace HIVMedicalSystem.WPFApplication.Pages.Staff;

public partial class TestResultsPage : Page
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ITestResultService _testResultService;
    public TestResultsPage(IServiceProvider serviceProvider, int roleAccess, int customerId)
    {
        _serviceProvider = serviceProvider;
        CustomerId = customerId;
        _testResultService = _serviceProvider.GetRequiredService<ITestResultService>();
        InitializeComponent();
    }
    
    public int CustomerId { get; set; }
    public int RoleAccess { get; set; }
    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        var result = new List<TestResult>();
        switch (RoleAccess)
        {
            case 1:
                result = await _testResultService.GetAllTestResults();
                dgData.ItemsSource = result;
                break;
            case 2:
                result = await _testResultService.GetAllTestResults();
                dgData.ItemsSource = result;
                break;
            case 3:
                result = await _testResultService.GetAllTestResultsByCustomerId(CustomerId);
                dgData.ItemsSource = result;
                break;
            case 4:
                break;
        }
    }

    private async void btnRefresh_Click(object sender, RoutedEventArgs e)
    {
        var result = new List<TestResult>();
        switch (RoleAccess)
        {
            case 1:
                result = await _testResultService.GetAllTestResults();
                dgData.ItemsSource = result;
                break;
            case 2:
                result = await _testResultService.GetAllTestResults();
                dgData.ItemsSource = result;
                break;
            case 3:
                result = await _testResultService.GetAllTestResultsByCustomerId(CustomerId);
                dgData.ItemsSource = result;
                break;
            case 4:
                break;
        }
    }

    private async void txtSearch_TextChanged(object sender, RoutedEventArgs e)
    {
        
    }
}