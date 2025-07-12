using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HIVMedicalSystem.Service.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace HIVMedicalSystem.WPFApplication;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IUserService _userService;
    public MainWindow(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _userService = _serviceProvider.GetRequiredService<IUserService>();
        InitializeComponent();
    }
    
    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {
            var result = await _userService.GetAllUsersAsync();
            dgData.ItemsSource = result;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}