using System.Windows;
using HIVMedicalSystem.Service.Abstraction;
using HIVMedicalSystem.WPFApplication.Pages.Admin;
using HIVMedicalSystem.WPFApplication.Pages.Customer;
using HIVMedicalSystem.WPFApplication.Pages.Staff;
using HIVMedicalSystem.WPFApplication.Windows.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace HIVMedicalSystem.WPFApplication.Windows.Doctor;

public partial class DoctorWindow : Window
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IUserService _userService;
    private readonly IAppointmentService _appointmentService;
    public DoctorWindow(IServiceProvider serviceProvider, int doctorId)
    {
        _serviceProvider = serviceProvider;
        _userService = _serviceProvider.GetRequiredService<IUserService>();
        _appointmentService = _serviceProvider.GetRequiredService<IAppointmentService>();
        DoctorId = doctorId;
        InitializeComponent();
    }
    
    public int DoctorId { get; set; }
    public int CurrentPage { get; set; }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        frmContent.Navigate(new AppointmentsPage(_serviceProvider, 4, DoctorId, 0));
        CurrentPage = 2;
    }

    private async void btnHome_Click(object sender, RoutedEventArgs e)
    {
        frmContent.Navigate(new HomePage());
        CurrentPage = 1;
    }

    private async void btnAppointments_Click(object sender, RoutedEventArgs e)
    {
        frmContent.Navigate(new AppointmentsPage(_serviceProvider, 4, DoctorId, 0));
        CurrentPage = 2;
    }

    private async void btnTreatmentPlan_Click(object sender, RoutedEventArgs e)
    {
        frmContent.Navigate(new TreatmentPlanPage(_serviceProvider));
        CurrentPage = 4;
    }

    private async void btnAnonymousSupport_Click(object sender, RoutedEventArgs e)
    {
        frmContent.Navigate(new CustomerSupport());
        CurrentPage = 5;
    }

    private async void btnTestResults_Click(object sender, RoutedEventArgs e)
    {
        
    }

    private async void btnMedicalRecords_Click(object sender, RoutedEventArgs e)
    {
        frmContent.Navigate(new MedicalRecordsPage(_serviceProvider, 4, 0));
        CurrentPage = 6;
    }
    
    
    private async void btnLogout_Click(object sender, RoutedEventArgs e)
    {
        var loginWindow = new LoginWindow(_serviceProvider);
        loginWindow.Show();
        this.Close();
    }

    private async void btnView_Click(object sender, RoutedEventArgs e)
    {
        switch (CurrentPage)
        {
            case 6:
                break;
        }
    }

    private async void btnCreateMedicalRecord_Click(object sender, RoutedEventArgs e)
    {
        switch (CurrentPage)
        {
            case 2:
                var appointmentContent = frmContent.Content as AppointmentsPage;
                var appointmentIdSelected = Int32.Parse(appointmentContent.AppointmentIdSelected.ToString());
                if (appointmentIdSelected == 0)
                {
                    MessageBox.Show("Please select an appointment");
                    return;
                }
                var createMedicalRecordWindow = new CreateMedicalRecord(_serviceProvider, appointmentIdSelected);
                createMedicalRecordWindow.Show();
                break;
        }
    }
}