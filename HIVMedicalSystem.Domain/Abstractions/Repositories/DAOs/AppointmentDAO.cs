using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.Domain.Abstractions.Repositories.DAOs;

public class AppointmentDAO: RepositoryBase<Appointment>
{
    private static AppointmentDAO _instance;

    public AppointmentDAO()
    {
    }

    public static AppointmentDAO Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new AppointmentDAO();
            }
            return _instance;
        }
    }
}