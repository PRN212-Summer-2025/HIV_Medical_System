using HIVMedicalSystem.Repository;
using HIVMedicalSystem.Repository.Abstraction;
using HIVMedicalSystem.Service;
using HIVMedicalSystem.Service.Abstraction;
using HIVMedicalSystem.WPFApplication.Windows.Admin;
using HIVMedicalSystem.WPFApplication.Windows.Authentication;
using HIVMedicalSystem.WPFApplication.Windows.Customer;
using HIVMedicalSystem.WPFApplication.Windows.Doctor;
using HIVMedicalSystem.WPFApplication.Windows.Staff;
using Microsoft.Extensions.DependencyInjection;

namespace HIVMedicalSystem.WPFApplication.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISeedingDatabaseRepository, SeedingDatabaseRepository>();
        services.AddScoped<ITestResultRepository, TestResultRepository>();
        services.AddScoped<IARVProtocolRepository, ARVProtocolRepository>();    
        services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ISeedingDatabaseService, SeedingDatabaseService>();
        services.AddScoped<IARVProtocolService, ARVProtocolService>();
        services.AddScoped<IMedicalRecordService, MedicalRecordService>();
        services.AddScoped<ITestResultService, TestResultService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        return services;
    }

    public static IServiceCollection AddWindows(this IServiceCollection services)
    {
        services.AddTransient<MainWindow>();
        services.AddTransient<HomeWindow>();
        services.AddTransient<LoginWindow>();
        services.AddTransient<AdminDashboard>();
        services.AddTransient<StaffDashboard>();
        services.AddTransient<ImportTestResultWindow>();
        services.AddTransient<DoctorWindow>();
        return services;
    }

    public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}