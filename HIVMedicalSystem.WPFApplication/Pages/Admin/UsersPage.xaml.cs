using System.Windows;
using System.Windows.Controls;
using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Service.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace HIVMedicalSystem.WPFApplication.Pages.Admin;

public partial class UsersPage : Page
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IUserService _userService;
    public UsersPage(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _userService = _serviceProvider.GetRequiredService<IUserService>();
        InitializeComponent();
    }
    
    public int UserIdSelected { get; set; }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        var result = await _userService.GetAllUsersAsync();
        dgData.ItemsSource = result;
    }

    private async void btnRefresh_Click(object sender, RoutedEventArgs e)
    {
        var result = await _userService.GetAllUsersAsync();
        dgData.ItemsSource = result;
    }

    private async void txtSearch_TextChanged(object sender, RoutedEventArgs e)
    {
        string search = txtSearch.Text;
        var users = await _userService.GetAllUsersAsync();
        if (!search.Equals(string.Empty)) users = await _userService.SearchUsers(search);
        dgData.ItemsSource = users;
    }

    private void dgData_SelectionChanged(object sender, RoutedEventArgs e)
    {
        if (dgData.SelectedValue is User user)
        {
            UserIdSelected = user.Id;
        }
        else
        {
            UserIdSelected = 0;
        }
    }
}