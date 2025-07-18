namespace HIVMedicalSystem.Domain.DTOs.Responses;

public class AppointmentResponse
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string DoctorName { get; set; }
    public string AppointmentDateTime { get; set; }
    public string Status { get; set; }
    public bool IsAnonymous { get; set; }
}