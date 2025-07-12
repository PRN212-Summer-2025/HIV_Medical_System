using HIVMedicalSystem.Repository;
using HIVMedicalSystem.Repository.Abstraction;
using HIVMedicalSystem.Service;
using HIVMedicalSystem.Service.Abstraction;
using HIVMedicalSystem.WPFApplication.Windows.Customer;
using Microsoft.Extensions.DependencyInjection;

namespace HIVMedicalSystem.WPFApplication.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }

    public static IServiceCollection AddWindows(this IServiceCollection services)
    {
        services.AddTransient<MainWindow>();
        services.AddTransient<HomeWindow>();
        return services;
    }

    public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
    {
        return services;
    }
}