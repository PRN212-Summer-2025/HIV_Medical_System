using System.Windows;
using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Service.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace HIVMedicalSystem.WPFApplication.Windows.Doctor;

public partial class CreateMedicalRecord : Window
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IMedicalRecordService _medicalRecordService;
    private readonly IUserService _userService;
    private readonly IARVProtocolService _arvProtocolService;
    private readonly IAppointmentService _appointmentService;
    public CreateMedicalRecord(IServiceProvider serviceProvider, int appointmentId)
    {
        _serviceProvider = serviceProvider;
        _medicalRecordService = _serviceProvider.GetRequiredService<IMedicalRecordService>();
        _userService = _serviceProvider.GetRequiredService<IUserService>();
        _arvProtocolService = _serviceProvider.GetRequiredService<IARVProtocolService>();
        _appointmentService = _serviceProvider.GetRequiredService<IAppointmentService>();
        AppointmentId = appointmentId;
        InitializeComponent();
    }
    
    public int AppointmentId { get; set; }
    
    public int DoctorId { get; set; }
    public int CustomerId { get; set; }
    public List<ARVProtocol> ARVProtocols { get; set; } = new List<ARVProtocol>();

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var appointment = await _appointmentService.GetAppointmentById(AppointmentId);
        DoctorId = appointment.DoctorId;
        CustomerId = appointment.CustomerId;
        var result = await _arvProtocolService.GetAllARVProtocols();
        cboProtocols.ItemsSource = result;
        cboProtocols.DisplayMemberPath = "Name";
        cboProtocols.SelectedValuePath = "Id";
        var doctor = await _userService.GetUserByIdAsync(DoctorId);
        var customer = await _userService.GetUserByIdAsync(CustomerId);
        txtCustomerName.Text = customer.FullName;
        txtDoctorName.Text = doctor.FullName;
    }

    private async void cboProtocols_SelectionChanged(object sender, RoutedEventArgs e)
    {
        ARVProtocols.Add(new ARVProtocol()
        {
            Id = Int32.Parse(cboProtocols.SelectedValue.ToString() ?? string.Empty)
        });
        var selectedItem = cboProtocols.SelectedItem as ARVProtocol;
        txtProtocols.Text += selectedItem.Name + ",";
        Console.WriteLine(ARVProtocols.Count);
    }

    private async void btnSave_Click(object sender, RoutedEventArgs e)
    {
        string treatmentNotes = txtNotes.Text;
        DateTime diagnosisDate = DateTime.Now;
        MedicalRecord medicalRecord = new MedicalRecord()
        {
            DoctorId = DoctorId,
            CustomerId = CustomerId,
            DiagnosisDate = diagnosisDate,
            IsDeleted = false,
            TreatmentNotes = treatmentNotes,
            ARVMedicalRecords = new List<ARVMedicalRecord>()
        };
        foreach (var item in ARVProtocols)
        {
            medicalRecord.ARVMedicalRecords.Add(new ARVMedicalRecord()
            {
                ARVProtocolId = item.Id
            });
        }
        await _medicalRecordService.AddNewMedicalRecord(medicalRecord);
        MessageBox.Show("Add new medical record success!");
        this.Close();
    }
}