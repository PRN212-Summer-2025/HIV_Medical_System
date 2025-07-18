using System.Windows;
using HIVMedicalSystem.Service.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace HIVMedicalSystem.WPFApplication.Windows.Customer;

public partial class MedicalRecordViewWindow : Window
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IMedicalRecordService _medicalRecordService;
    public MedicalRecordViewWindow(IServiceProvider serviceProvider, int medicalRecordId)
    {
        _serviceProvider = serviceProvider;
        _medicalRecordService = _serviceProvider.GetRequiredService<IMedicalRecordService>();
        MedicalRecordId = medicalRecordId;    
        InitializeComponent();
    }
    
    public int MedicalRecordId { get; set; }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        
    }

    private async void btnClose_Click(object sender, RoutedEventArgs e)
    {
        
    }
}