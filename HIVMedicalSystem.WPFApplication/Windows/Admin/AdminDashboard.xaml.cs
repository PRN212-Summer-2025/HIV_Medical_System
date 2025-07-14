using System.Windows;
using HIVMedicalSystem.WPFApplication.Pages.Admin;

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
        frmContent.Navigate(new UsersPage(_serviceProvider));
    }
}
