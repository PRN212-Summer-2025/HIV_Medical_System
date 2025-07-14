using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Repository.Abstraction;

public interface IAppointmentRepository
{
    public Task<List<Appointment>> GetAllAppointments();
    public Task<List<Appointment>> GetAllAppointmentsByCustomerId(int customerId);
    public Task<List<Appointment>> GetAllAppointmentsByDoctorId(int doctorId);
    public Task AddNewAppointment(Appointment appointment);
    public Task UpdateAppointment(Appointment appointment);
    public Task DeleteAppointment(int appointmentId);
}