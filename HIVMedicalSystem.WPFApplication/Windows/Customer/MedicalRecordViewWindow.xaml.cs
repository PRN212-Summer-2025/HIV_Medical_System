using System.Windows;
using HIVMedicalSystem.Domain.DTOs.Responses;
using HIVMedicalSystem.Service.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace HIVMedicalSystem.WPFApplication.Windows.Customer;

public partial class MedicalRecordViewWindow : Window
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IMedicalRecordService _medicalRecordService;
    public MedicalRecordViewWindow(IServiceProvider serviceProvider, int roleAccess, int medicalRecordId)
    {
        _serviceProvider = serviceProvider;
        _medicalRecordService = _serviceProvider.GetRequiredService<IMedicalRecordService>();
        MedicalRecordId = medicalRecordId;
        RoleAccess = roleAccess;
        InitializeComponent();
    }
    public int RoleAccess { get; set; }
    public int MedicalRecordId { get; set; }
    public MedicalRecordResponse MedicalRecord { get; set; }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        switch (RoleAccess)
        {
            case 3:
                MedicalRecord = await _medicalRecordService.GetMedicalRecordById(MedicalRecordId);
                txtCustomerName.Text = MedicalRecord.CustomerName;
                txtDoctorName.Text = MedicalRecord.DoctorName;
                txtNotes.Text = MedicalRecord.TreatmentNotes;
                txtRecordId.Text = MedicalRecord.Id.ToString();
                dgData.ItemsSource = MedicalRecord.ARVProtocols;
                break;
            case 4:
                MedicalRecord = await _medicalRecordService.GetMedicalRecordById(MedicalRecordId);
                txtCustomerName.Text = MedicalRecord.CustomerName;
                txtDoctorName.Text = MedicalRecord.DoctorName;
                txtNotes.Text = MedicalRecord.TreatmentNotes;
                txtRecordId.Text = MedicalRecord.Id.ToString();
                dgData.ItemsSource = MedicalRecord.ARVProtocols;
                break;
        }
    }

    private async void btnClose_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}