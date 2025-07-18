using System.Windows;
using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Service.Abstraction;
using HIVMedicalSystem.WPFApplication.Pages.Customer;
using HIVMedicalSystem.WPFApplication.Windows.Admin;
using HIVMedicalSystem.WPFApplication.Windows.Customer;
using HIVMedicalSystem.WPFApplication.Windows.Doctor;
using HIVMedicalSystem.WPFApplication.Windows.Staff;
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
        var user = new User();
        switch (result)
        {
            case 0:
                MessageBox.Show("Wrong credentials. Please try again!");
                break;
            case 1:
                var staffWindow = new StaffDashboard(_serviceProvider);
                this.Close();
                staffWindow.Show();
                MessageBox.Show("Login success as staff role!");
                break;
            case 2:
                var adminWindow = new AdminDashboard(_serviceProvider);
                this.Close();
                adminWindow.Show();
                MessageBox.Show("Login success as Admin role!");
                break;
            case 3:
                user = await _userService.GetUserByEmailAsync(email);
                Console.WriteLine(user.Id);
                var customerWindow = new HomeWindow(_serviceProvider, user.Id);
                this.Close();
                customerWindow.Show();
                MessageBox.Show("Login success as Customer role!");
                break;
            case 4:
                user = await _userService.GetUserByEmailAsync(email);
                var doctorWindow = new DoctorWindow(_serviceProvider, user.Id);
                this.Close();
                doctorWindow.Show();
                break;
        }
    }
}