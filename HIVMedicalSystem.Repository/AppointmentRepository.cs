using HIVMedicalSystem.Domain.Abstractions.Repositories.DAOs;
using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Repository.Abstraction;

namespace HIVMedicalSystem.Repository;

public class AppointmentRepository: IAppointmentRepository
{
    public async Task<List<Appointment>> GetAllAppointments()
    {
        var result = await AppointmentDAO.Instance.Get();
        return result.ToList();
    }

    public async Task<List<Appointment>> GetAllAppointmentsByCustomerId(int customerId)
    {
        var result = await AppointmentDAO.Instance.Get(filter: filter => filter.CustomerId == customerId);
        return result.ToList();
    }

    public async Task<List<Appointment>> GetAllAppointmentsByDoctorId(int doctorId)
    {
        var result = await AppointmentDAO.Instance.Get(filter: filter => filter.DoctorId == doctorId);
        return result.ToList();
    }

    public async Task AddNewAppointment(Appointment appointment)
    {
        AppointmentDAO.Instance.Insert(appointment);
    }

    public async Task UpdateAppointment(Appointment appointment)
    {
        await AppointmentDAO.Instance.Update(appointment);
    }

    public async Task DeleteAppointment(int appointmentId)
    {
        await AppointmentDAO.Instance.Delete(appointmentId);
    }
}