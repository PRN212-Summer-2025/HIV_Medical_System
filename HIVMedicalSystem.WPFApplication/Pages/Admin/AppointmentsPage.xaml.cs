using System.Windows;
using System.Windows.Controls;
using HIVMedicalSystem.Domain.DTOs.Responses;
using HIVMedicalSystem.Service.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace HIVMedicalSystem.WPFApplication.Pages.Admin;

public partial class AppointmentsPage : Page
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IAppointmentService _appointmentService;
    public AppointmentsPage(IServiceProvider serviceProvider, int roleAccess, int doctorId, int customerId)
    {
        _serviceProvider = serviceProvider;
        DoctorId = doctorId;
        CustomerId = customerId;
        RoleAccess = roleAccess;
        Console.WriteLine(customerId);
        _appointmentService = _serviceProvider.GetRequiredService<IAppointmentService>();
        AppointmentIdSelected = 0;
        InitializeComponent();
    }
    
    public int DoctorId { get; set; }
    public int CustomerId { get; set; }
    public int RoleAccess { get; set; }
    public DateTime SelectedDate { get; set; }
    public int AppointmentIdSelected { get; set; }
    
    private async void dpDate_SelectedDateChanged(object sender, RoutedEventArgs e)
    {
        SelectedDate = GetDateTimeFromDatePicker();
        switch (RoleAccess)
        {
            case 4:
                var result = await _appointmentService.GetAllAppointmentsByDoctorId(DoctorId, SelectedDate);
                dgData.ItemsSource = result;
                break;
        }
    }
    
    private DateTime GetDateTimeFromDatePicker()
    {
        if (dpDate.SelectedDate.HasValue)
        {
            DateTime selectedDate = dpDate.SelectedDate.Value;
        }
        
        DateTime? date = dpDate.SelectedDate;

        DateTime fullDateTime = DateTime.Now;
        if (date.HasValue)
        {
            fullDateTime = date.Value.Date;
        }

        return fullDateTime;
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        var result = new List<AppointmentResponse>();
        switch (RoleAccess)
        {
            case 1:
                result = await _appointmentService.GetAllAppointments();
                dgData.ItemsSource = result;
                break;
            case 2:
                result = await _appointmentService.GetAllAppointments();
                dgData.ItemsSource = result;
                break;
            case 3:
                result = await _appointmentService.GetAllAppointmentByCustomerId(CustomerId);
                dgData.ItemsSource = result;
                break;
            case 4:
                SelectedDate = DateTime.Now;
                result = await _appointmentService.GetAllAppointmentsByDoctorId(DoctorId, new DateTime(2025, 7, 19));
                dgData.ItemsSource = result;
                break;
        }
    }

    private async void btnRefresh_Click(object sender, RoutedEventArgs e)
    {
        var result = new List<AppointmentResponse>();
        switch (RoleAccess)
        {
            case 1:
                result = await _appointmentService.GetAllAppointments();
                dgData.ItemsSource = result;
                break;
            case 2:
                result = await _appointmentService.GetAllAppointments();
                dgData.ItemsSource = result;
                break;
            case 3:
                result = await _appointmentService.GetAllAppointmentByCustomerId(CustomerId);
                dgData.ItemsSource = result;
                break;
            case 4:
                result = await _appointmentService.GetAllAppointmentsByDoctorId(DoctorId, new DateTime(2025, 7, 19));
                dgData.ItemsSource = result;
                break;
        }
    }

    private async void dgData_SelectionChanged(object sender, RoutedEventArgs e)
    {
        if (dgData.SelectedValue is AppointmentResponse appointment)
        {
            AppointmentIdSelected = appointment.Id;
        }
        else
        {
            AppointmentIdSelected = 0;
        }
    }
}