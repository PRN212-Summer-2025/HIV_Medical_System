using System.Windows;
using HIVMedicalSystem.Service.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace HIVMedicalSystem.WPFApplication.Windows.Authentication;

public partial class LoginWindow : Window
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IUserService _userService;
    
    public LoginWindow(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _userService = _serviceProvider.GetRequiredService<IUserService>();
        InitializeComponent();
    }

    private async void btnLogin_Click(object sender, RoutedEventArgs e)
    {
        string email = txtEmail.Text;
        string password = txtPassword.Password;
        if (password.Length == 0) MessageBox.Show("Please enter a valid password.");
        var result = await _userService.Authentication(email, password);
        switch (result)
        {
            case 0:
                MessageBox.Show("Wrong credentials. Please try again!");
                break;
            case 1:
                MessageBox.Show("Login success as staff role!");
                break;
            case 2:
                MessageBox.Show("Login success as Admin role!");
                break;
            case 3:
                MessageBox.Show("Login success as Customer role!");
                break;
            case 4:
                MessageBox.Show("Login success as Doctor role!");
                break;
        }
    }
}