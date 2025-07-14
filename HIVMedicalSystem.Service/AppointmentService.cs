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
    
    public async Task<List<Appointment>> GetAllAppointments()
    {
        return await _appointmentRepository.GetAllAppointments();
    }

    public async Task<List<Appointment>> GetAllAppointmentByCustomerId(int customerId)
    {
        return await _appointmentRepository.GetAllAppointmentsByCustomerId(customerId);
    }

    public async Task<List<Appointment>> GetAllAppointmentsByDoctorId(int doctorId)
    {
        return await _appointmentRepository.GetAllAppointmentsByDoctorId(doctorId);
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