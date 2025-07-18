using System.Windows;
using HIVMedicalSystem.WPFApplication.Pages.Admin;
using HIVMedicalSystem.WPFApplication.Pages.Customer;
using HIVMedicalSystem.WPFApplication.Pages.Staff;
using HIVMedicalSystem.WPFApplication.Windows.Authentication;

namespace HIVMedicalSystem.WPFApplication.Windows.Customer;

public partial class HomeWindow : Window
{
    private readonly IServiceProvider _serviceProvider;
    public HomeWindow(IServiceProvider serviceProvider, int customerId)
    {
        CustomerId = customerId;
        _serviceProvider = serviceProvider;
        InitializeComponent();
    }
    
    public int CustomerId { get; set; }
    public int CurrentPage { get; set; }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        CurrentPage = 1;
        frmContent.Navigate(new HomePage());
    }
    
    private void btnHome_Click(object sender, RoutedEventArgs e)
    {
        CurrentPage = 1;
        frmContent.Navigate(new HomePage());
    }

    private void btnCustomerSupport_Click(object sender, RoutedEventArgs e)
    {
        CurrentPage = 5;
        frmContent.Navigate(new CustomerSupport());
    }

    private async void btnMedicalRecords_Click(object sender, RoutedEventArgs e)
    {
        frmContent.Navigate(new MedicalRecordsPage(_serviceProvider, 3, CustomerId));
        CurrentPage = 6;
    }

    private async void btnAppointments_Click(object sender, RoutedEventArgs e)
    {
        CurrentPage = 2;
        frmContent.Navigate(new AppointmentsPage(_serviceProvider, 3, 0, CustomerId));
    }

    private async void btnTestResults_Click(object sender, RoutedEventArgs e)
    {
        CurrentPage = 3;
        frmContent.Navigate(new TestResultsPage(_serviceProvider, 3, CustomerId));
    }

    private async void btnDoctor_Click(object sender, RoutedEventArgs e)
    {
        CurrentPage = 4;
        frmContent.Navigate(new UsersPage(_serviceProvider, 3));
    }

    private async void btnBookAppointment_Click(object sender, RoutedEventArgs e)
    {
        var userContent = frmContent.Content as UsersPage;
        Console.WriteLine(userContent.UserIdSelected);
        var bookingAppointmentWindow =
            new BookingAppointmentWindow(_serviceProvider, 
                CustomerId,
                Int32.Parse(userContent.UserIdSelected.ToString() ?? string.Empty));
        bookingAppointmentWindow.Show();
    }

    private async void btnView_Click(object sender, RoutedEventArgs e)
    {
        switch (CurrentPage)
        {
            case 6:
                
                break;
        }
    }

    private async void btnLogout_Click(object sender, RoutedEventArgs e)
    {
        var loginWindow = new LoginWindow(_serviceProvider);
        loginWindow.Show();
        this.Close();
    }
}