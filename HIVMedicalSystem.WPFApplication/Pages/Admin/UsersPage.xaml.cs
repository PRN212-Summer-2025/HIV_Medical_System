using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using HIVMedicalSystem.Domain.DTOs.Responses;
using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Service.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace HIVMedicalSystem.WPFApplication.Pages.Admin;

public partial class UsersPage : Page
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IUserService _userService;
    public UsersPage(IServiceProvider serviceProvider, int roleAccess)
    {
        _serviceProvider = serviceProvider;
        RoleAccess = roleAccess;
        _userService = _serviceProvider.GetRequiredService<IUserService>();
        InitializeComponent();
    }
    
    public int RoleAccess { get; set; }
    
    public int UserIdSelected { get; set; }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        var result = new List<UserDTO>();
        switch (RoleAccess)
        {
            case 1:
                result = await _userService.GetAllCustomersAsync();
                dgData.ItemsSource = result;
                break;
            case 2:
                result = await _userService.GetAllUsersAsync();
                dgData.ItemsSource = result;
                break;
            case 3:
                result = await _userService.GetAllDoctorsAsync();
                dgData.ItemsSource = result;
                break;
            case 4:
                break;
        }
    }

    private async void btnRefresh_Click(object sender, RoutedEventArgs e)
    {
        var result = new List<UserDTO>();
        switch (RoleAccess)
        {
            case 1:
                result = await _userService.GetAllCustomersAsync();
                break;
            case 2:
                result = await _userService.GetAllUsersAsync();
                dgData.ItemsSource = result;
                break;
            case 3:
                result = await _userService.GetAllDoctorsAsync();
                break;
            case 4:
                break;
        }
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
        if (dgData.SelectedValue is UserDTO user)
        {
            UserIdSelected = user.Id;
        }
        else
        {
            UserIdSelected = 0;
        }
    }
}