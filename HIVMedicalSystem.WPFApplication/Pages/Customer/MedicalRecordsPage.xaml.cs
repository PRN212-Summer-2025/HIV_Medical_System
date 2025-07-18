using System.Windows;
using System.Windows.Controls;
using HIVMedicalSystem.Domain.DTOs.Responses;
using HIVMedicalSystem.Service.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace HIVMedicalSystem.WPFApplication.Pages.Customer;

public partial class MedicalRecordsPage : Page
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IMedicalRecordService _medicalRecordService;
    
    public MedicalRecordsPage(IServiceProvider serviceProvider, int roleAccess, int customerId)
    {
        _serviceProvider = serviceProvider;
        _medicalRecordService = _serviceProvider.GetRequiredService<IMedicalRecordService>();
        RoleAccess = roleAccess;
        CustomerId = customerId;
        InitializeComponent();
    }
    
    public int CustomerId { get; set; }
    public int RoleAccess { get; set; }
    public int MedicalRecordIdSelected { get; set; }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        var result = new List<MedicalRecordResponse>();
        switch (RoleAccess)
        {
            case 3:
                result = await _medicalRecordService.GetAllMedicalRecordsByCustomerId(CustomerId);
                dgData.ItemsSource = result;
                break;
            case 4: 
                result = await _medicalRecordService.GetAllMedicalRecords();
                dgData.ItemsSource = result;
                break;
        }
    }

    private async void btnRefresh_Click(object sender, RoutedEventArgs e)
    {
        var result = new List<MedicalRecordResponse>();
        switch (RoleAccess)
        {
            case 3:
                result = await _medicalRecordService.GetAllMedicalRecordsByCustomerId(CustomerId);
                dgData.ItemsSource = result;
                break;
            case 4: 
                result = await _medicalRecordService.GetAllMedicalRecords();
                dgData.ItemsSource = result;
                break;
        }
    }

    private async void dgData_SelectionChanged(object sender, RoutedEventArgs e)
    {
        if (dgData.SelectedValue is MedicalRecordResponse medicalRecord)
        {
            MedicalRecordIdSelected = medicalRecord.Id;
        }
        else
        {
            MedicalRecordIdSelected = 0;
        }
    }
}