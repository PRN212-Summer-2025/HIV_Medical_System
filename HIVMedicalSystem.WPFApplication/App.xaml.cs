using System.Configuration;
using System.Data;
using System.Windows;
using HIVMedicalSystem.WPFApplication.Configuration;
using HIVMedicalSystem.WPFApplication.Windows.Customer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HIVMedicalSystem.WPFApplication;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddRepositories();
                services.AddServices();
                services.AddWindows();
                services.AddAutoMapperConfiguration();
                /*
                QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
            */
            })
            .Build();
    }
    
    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host.StartAsync();
        
        // Open the login window
        var window = _host.Services.GetRequiredService<HomeWindow>();
        window.Show();
        base.OnStartup(e);
    }
    
    protected override async void OnExit(ExitEventArgs e)
    {
        await _host.StopAsync();
        _host.Dispose();
        base.OnExit(e);
    }
}