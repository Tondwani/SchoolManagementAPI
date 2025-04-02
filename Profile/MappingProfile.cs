using AlrightAPI.Models;
using AlrightAPI.MappingProfiles;  
using AutoMapper;
using AlrightAPI.NewFolder;
using AlrightAPI.Models.Entities;
using AlrightAPI.Models.Dto_s;

namespace AlrightAPI.MappingProfiles  
{
    public class MappingProfile : Profile  
    {
        public MappingProfile()  // constructor
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Teacher, TeacherDto>().ReverseMap();
        }
    }
}
