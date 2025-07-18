using HIVMedicalSystem.Domain.DTOs.Responses;
using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Repository.Abstraction;

public interface IAppointmentRepository
{
    public Task<List<AppointmentResponse>> GetAllAppointments();
    public Task<List<AppointmentResponse>> GetAllAppointmentsByCustomerId(int customerId);
    public Task<List<AppointmentResponse>> GetAllAppointmentsByDoctorId(int doctorId, DateTime date);
    public Task<Appointment> GetAppointmentById(int appointmentId);
    public Task AddNewAppointment(Appointment appointment);
    public Task UpdateAppointment(Appointment appointment);
    public Task DeleteAppointment(int appointmentId);
}