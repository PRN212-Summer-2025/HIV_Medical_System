using AutoMapper;
using HIVMedicalSystem.Domain.DTOs.Responses;
using HIVMedicalSystem.Domain.Entities;

namespace HIVMedicalSystem.WPFApplication.Configuration.Mapper;

public class MapperProfile: Profile
{
    public MapperProfile()
    {
        TestResultMapperProfile();
        UserMapperProfile();
        AppointmentMapperProfile();
    }

    public void AppointmentMapperProfile()
    {
        CreateMap<Appointment, AppointmentResponse>()
            .ForMember(dest => dest.CustomerName,
                option => option.MapFrom(schema => schema.Customer.FullName))
            .ForMember(dest => dest.DoctorName,
                option => option.MapFrom(schema => schema.Doctor.FullName))
            .ForMember(dest => dest.AppointmentDateTime,
                option => option.MapFrom(schema => schema.AppointmentDateTime.ToString("dd-MM-yyyy")));
    }

    public void TestResultMapperProfile()
    {
        
    }

    public void UserMapperProfile()
    {
        CreateMap<User, UserDTO>()
            .ForMember(dest => dest.RoleName,
                option => option.MapFrom(schema => schema.Role.RoleName));
    }

    public void MedicalRecordMapperProfile()
    {
        CreateMap<MedicalRecord, MedicalRecordResponse>()
            .ForMember(dest => dest.CustomerName,
                option => option.MapFrom(schema => schema.Customer.FullName))
            .ForMember(dest => dest.DoctorName,
                option => option.MapFrom(schema => schema.Doctor.FullName))
            .ForMember(dest => dest.DiagnosisDate,
                option => option.MapFrom(schema => schema.DiagnosisDate.ToString("dd-MM-yyyy")));
        
    }
}