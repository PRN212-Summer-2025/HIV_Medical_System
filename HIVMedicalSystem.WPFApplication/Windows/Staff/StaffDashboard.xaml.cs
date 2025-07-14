using System.Windows;
using HIVMedicalSystem.WPFApplication.Pages.Admin;
using HIVMedicalSystem.WPFApplication.Pages.Customer;
using HIVMedicalSystem.WPFApplication.Pages.Staff;

namespace HIVMedicalSystem.WPFApplication.Windows.Staff;

public partial class StaffDashboard : Window
{
    private readonly IServiceProvider _serviceProvider;
    public StaffDashboard(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
    }
    
    public int CurrentPage { get; set; }
    
    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        frmContent.Navigate(new UsersPage(_serviceProvider));
        CurrentPage = 1;
    }

    private async void btnUsers_Click(object sender, RoutedEventArgs e)
    {
        frmContent.Navigate(new UsersPage(_serviceProvider));
        CurrentPage = 1;
    }

    private async void btnTestResult_Click(object sender, RoutedEventArgs e)
    {
        frmContent.Navigate(new TestResultsPage(_serviceProvider));
        CurrentPage = 2;
    }
    

    private async void btnView_Click(object sender, RoutedEventArgs e)
    {
        switch (CurrentPage)
        {
            case 1:
                break;
            case 2: 
                break;
        }
    }

    private async void btnAnonymousSupport_Click(object sender, RoutedEventArgs e)
    {
        frmContent.Navigate(new CustomerSupport());
        CurrentPage = 3;
    }

    private async void btnTreatmentPlan_Click(object sender, RoutedEventArgs e)
    {
        frmContent.Navigate(new TreatmentPlanPage(_serviceProvider));
        CurrentPage = 4;
    }

    private async void btnUpdate_Click(object sender, RoutedEventArgs e)
    {
        
    }

    private async void btnUpdateTest_Click(object sender, RoutedEventArgs e)
    {
        
    }
}