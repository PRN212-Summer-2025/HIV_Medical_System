using HIVMedicalSystem.Repository;
using HIVMedicalSystem.Repository.Abstraction;
using HIVMedicalSystem.Service;
using HIVMedicalSystem.Service.Abstraction;
using HIVMedicalSystem.WPFApplication.Windows.Admin;
using HIVMedicalSystem.WPFApplication.Windows.Authentication;
using HIVMedicalSystem.WPFApplication.Windows.Customer;
using Microsoft.Extensions.DependencyInjection;

namespace HIVMedicalSystem.WPFApplication.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISeedingDatabaseRepository, SeedingDatabaseRepository>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ISeedingDatabaseService, SeedingDatabaseService>();
        return services;
    }

    public static IServiceCollection AddWindows(this IServiceCollection services)
    {
        services.AddTransient<MainWindow>();
        services.AddTransient<HomeWindow>();
        services.AddTransient<LoginWindow>();
        services.AddTransient<AdminDashboard>();
        return services;
    }

    public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
    {
        return services;
    }
}