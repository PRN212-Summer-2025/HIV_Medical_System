using System.Windows;
using HIVMedicalSystem.WPFApplication.Pages.Admin;
using HIVMedicalSystem.WPFApplication.Pages.Customer;
using HIVMedicalSystem.WPFApplication.Pages.Staff;
using HIVMedicalSystem.WPFApplication.Windows.Authentication;

namespace HIVMedicalSystem.WPFApplication.Windows.Admin;

public partial class AdminDashboard : Window
{
    private readonly IServiceProvider _serviceProvider;
    
    public AdminDashboard(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        frmContent.Navigate(new UsersPage(_serviceProvider, 2));
    }
    
    public int CurrentPage { get; set; }

    private async void btnUsers_Click(object sender, RoutedEventArgs e)
    {
        frmContent.Navigate(new UsersPage(_serviceProvider, 2));
        CurrentPage = 1;
    }

    private async void btnStaff_Click(object sender, RoutedEventArgs e)
    {
        
    }

    private async void btnTestResult_Click(object sender, RoutedEventArgs e)
    {
        frmContent.Navigate(new TestResultsPage(_serviceProvider, 2, 0));
        CurrentPage = 5;
    }

    private async void btnAppointments_Click(object sender, RoutedEventArgs e)
    {
        frmContent.Navigate(new AppointmentsPage(_serviceProvider, 1, 0,0));
        CurrentPage = 2;
    }

    private async void btnTreatmentPlan_Click(object sender, RoutedEventArgs e)
    {
        frmContent.Navigate(new TreatmentPlanPage(_serviceProvider));
        CurrentPage = 3;
    }

    private async void btnAnonymousSupport_Click(object sender, RoutedEventArgs e)
    {
        frmContent.Navigate(new CustomerSupport());
        CurrentPage = 4;
    }

    private async void btnLogout_Click(object sender, RoutedEventArgs e)
    {
        var loginWindow = new LoginWindow(_serviceProvider);
        loginWindow.Show();
        this.Close();
    }
    
    
}
