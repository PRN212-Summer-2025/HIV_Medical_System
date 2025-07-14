using System.Windows;

namespace HIVMedicalSystem.WPFApplication.Windows.Staff;

public partial class StaffDashboard : Window
{
    public StaffDashboard()
    {
        InitializeComponent();
    }
    
    public int CurrentPage { get; set; }
    
    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        
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

    private async void btnUpdate_Click(object sender, RoutedEventArgs e)
    {
        
    }

    private async void btnUpdateTest_Click(object sender, RoutedEventArgs e)
    {
        
    }
}