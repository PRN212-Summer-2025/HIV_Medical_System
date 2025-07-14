using System.Windows;
using System.Windows.Controls;
using HIVMedicalSystem.Service.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace HIVMedicalSystem.WPFApplication.Pages.Staff;

public partial class TestResultsPage : Page
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ITestResultService _testResultService;
    public TestResultsPage(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _testResultService = _serviceProvider.GetRequiredService<ITestResultService>();
        InitializeComponent();
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        var result = await _testResultService.GetAllTestResults();
        dgData.ItemsSource = result;
    }

    private async void btnRefresh_Click(object sender, RoutedEventArgs e)
    {
        var result = await _testResultService.GetAllTestResults();
        dgData.ItemsSource = result;
    }

    private async void txtSearch_TextChanged(object sender, RoutedEventArgs e)
    {
        
    }
}