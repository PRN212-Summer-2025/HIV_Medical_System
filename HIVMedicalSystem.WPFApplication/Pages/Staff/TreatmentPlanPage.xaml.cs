using System.Windows;
using System.Windows.Controls;
using HIVMedicalSystem.Service.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace HIVMedicalSystem.WPFApplication.Pages.Staff;

public partial class TreatmentPlanPage : Page
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IARVProtocolService _arvProtocolService;
    public TreatmentPlanPage(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _arvProtocolService = _serviceProvider.GetRequiredService<IARVProtocolService>();
        InitializeComponent();
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        var result = await _arvProtocolService.GetAllARVProtocols();
        dgData.ItemsSource = result;
    }

    private async void btnRefresh_Click(object sender, RoutedEventArgs e)
    {
        var result = await _arvProtocolService.GetAllARVProtocols();
        dgData.ItemsSource = result;
    }
}