using System.Windows;
using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Service.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace HIVMedicalSystem.WPFApplication.Windows.Customer;

public partial class BookingAppointmentWindow : Window
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IAppointmentService _appointmentService;
    private readonly IUserService _userService;
    public BookingAppointmentWindow(IServiceProvider serviceProvider, int customerId, int doctorId)
    {
        _serviceProvider = serviceProvider;
        _appointmentService = _serviceProvider.GetRequiredService<IAppointmentService>();
        _userService = _serviceProvider.GetRequiredService<IUserService>();
        CustomerId = customerId;
        DoctorId = doctorId;
        InitializeComponent();
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var isAnonymousOption = new string[] { "True", "False" };
        cboIsAnonymous.ItemsSource = isAnonymousOption;
        var doctor = await _userService.GetUserByIdAsync(DoctorId);
        txtDoctorName.Text = doctor.FullName;
    }
    
    public int CustomerId { get; set; }
    public int DoctorId { get; set; }
    public DateTime AppointmentDateTime { get; set; }

    private async void btnSave_Click(object sender, RoutedEventArgs e)
    {
        bool isAnonymous = bool.Parse((string) cboIsAnonymous.SelectedValue);
        Appointment appointment = new Appointment()
        {
            CustomerId = CustomerId,
            DoctorId = DoctorId,
            AppointmentDateTime = AppointmentDateTime,
            IsAnonymous = isAnonymous
        };
        await _appointmentService.AddNewAppointment(appointment);
        MessageBox.Show("Appointment added!");
        this.Close();
    }

    private void dpAppointmentDate_SelectedDateChanged(object sender, RoutedEventArgs e)
    {
        AppointmentDateTime = GetDateTimeFromDatePicker();
    }
    
    private DateTime GetDateTimeFromDatePicker()
    {
        if (dpAppointmentDate.SelectedDate.HasValue)
        {
            DateTime selectedDate = dpAppointmentDate.SelectedDate.Value;
        }
        
        DateTime? date = dpAppointmentDate.SelectedDate;

        DateTime fullDateTime = DateTime.Now;
        if (date.HasValue)
        {
            fullDateTime = date.Value.Date;
        }

        return fullDateTime;
    }
}