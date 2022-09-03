using API.DTOs.Department;
using API.DTOs.Event;
using API.DTOs.Subject;
using API.DTOs.UserType;
using API.Entities;
using AutoMapper;

namespace API.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Subject
            CreateMap<Subject, GetSubjectDTO>().ReverseMap();
            CreateMap<CreateSubjectDTO, Subject>();
            CreateMap<UpdateSubjectDTO, Subject>();

            // Department
            CreateMap<Department, GetDepartmentDTO>().ReverseMap();
            CreateMap<CreateDepartmentDTO, Department>();
            CreateMap<UpdateDepartmentDTO, Department>();

            //Event
            CreateMap<Event, GetEventDTO>().ReverseMap();
            CreateMap<CreateEventDTO, Event>();
            CreateMap<UpdateEventDTO, Event>();

            //UserType
            CreateMap<UserType, GetUserTypeDTO>().ReverseMap();
            CreateMap<CreateUserTypeDTO, UserType>();
            CreateMap<UpdateUserTypeDTO, UserType>();

        }
    }
}
