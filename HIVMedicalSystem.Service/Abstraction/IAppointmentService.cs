using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Service.Abstraction;

public interface IAppointmentService
{
    public Task<List<Appointment>> GetAllAppointments();
    public Task<List<Appointment>> GetAllAppointmentByCustomerId(int customerId);
    public Task<List<Appointment>> GetAllAppointmentsByDoctorId(int doctorId);
    public Task AddNewAppointment(Appointment appointment);
    public Task UpdateAppointment(Appointment appointment);
    public Task DeleteAppointment(int appointmentId);
}