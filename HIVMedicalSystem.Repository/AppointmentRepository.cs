using AutoMapper;
using HIVMedicalSystem.Domain.Abstractions.Repositories.DAOs;
using HIVMedicalSystem.Domain.DTOs.Responses;
using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Repository.Abstraction;

namespace HIVMedicalSystem.Repository;

public class AppointmentRepository: IAppointmentRepository
{
    private readonly IMapper _mapper;

    public AppointmentRepository(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<List<AppointmentResponse>> GetAllAppointments()
    {
        var result = await AppointmentDAO.Instance.Get(null, null, "Customer,Doctor");
        return _mapper.Map<List<AppointmentResponse>>(result);
    }

    public async Task<List<AppointmentResponse>> GetAllAppointmentsByCustomerId(int customerId)
    {
        var result = await AppointmentDAO.Instance.Get(filter: filter => filter.CustomerId == customerId, null, "Customer,Doctor");
        return _mapper.Map<List<AppointmentResponse>>(result);
    }

    public async Task<List<AppointmentResponse>> GetAllAppointmentsByDoctorId(int doctorId, DateTime date)
    {
        var result = await AppointmentDAO.Instance.Get(filter: filter => filter.DoctorId == doctorId && filter.AppointmentDateTime == date, null, "Customer,Doctor");
        return _mapper.Map<List<AppointmentResponse>>(result);
    }

    public async Task<Appointment> GetAppointmentById(int appointmentId)
    {
        var appointments = await AppointmentDAO.Instance.Get(filter => filter.Id == appointmentId);
        return appointments.FirstOrDefault()!;
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