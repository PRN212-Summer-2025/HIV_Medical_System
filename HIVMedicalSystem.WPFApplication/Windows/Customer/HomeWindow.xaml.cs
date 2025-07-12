using System.Windows;
using HIVMedicalSystem.WPFApplication.Pages.Customer;

namespace HIVMedicalSystem.WPFApplication.Windows.Customer;

public partial class HomeWindow : Window
{
    public HomeWindow()
    {
        InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        CurrentPage = 1;
        frmContent.Navigate(new HomePage());
    }
    
    public int CurrentPage { get; set; }

    private void btnHome_Click(object sender, RoutedEventArgs e)
    {
        CurrentPage = 1;
        frmContent.Navigate(new HomePage());
    }

    private void btnCustomerSupport_Click(object sender, RoutedEventArgs e)
    {
        CurrentPage = 2;
        frmContent.Navigate(new CustomerSupport());
    }
}