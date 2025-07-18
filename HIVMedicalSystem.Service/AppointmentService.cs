using HIVMedicalSystem.Domain.DTOs.Responses;
using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Repository.Abstraction;
using HIVMedicalSystem.Service.Abstraction;

namespace HIVMedicalSystem.Service;

public class AppointmentService: IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentService(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }
    
    public async Task<List<AppointmentResponse>> GetAllAppointments()
    {
        return await _appointmentRepository.GetAllAppointments();
    }

    public async Task<List<AppointmentResponse>> GetAllAppointmentByCustomerId(int customerId)
    {
        return await _appointmentRepository.GetAllAppointmentsByCustomerId(customerId);
    }

    public async Task<List<AppointmentResponse>> GetAllAppointmentsByDoctorId(int doctorId, DateTime date)
    {
        var result = await _appointmentRepository.GetAllAppointmentsByDoctorId(doctorId, date);
        foreach (var item in result)
        {
            if (item.IsAnonymous) item.CustomerName = "Anonymous";
        }
        return result;
    }

    public async Task<Appointment> GetAppointmentById(int appointmentId)
    {
        return await _appointmentRepository.GetAppointmentById(appointmentId);
    }

    public async Task AddNewAppointment(Appointment appointment)
    {
        await _appointmentRepository.AddNewAppointment(appointment);
    }

    public async Task UpdateAppointment(Appointment appointment)
    {
        await _appointmentRepository.UpdateAppointment(appointment);
    }

    public async Task DeleteAppointment(int appointmentId)
    {
        await _appointmentRepository.DeleteAppointment(appointmentId);
    }
}