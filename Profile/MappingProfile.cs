using AlrightAPI.Models;
using AlrightAPI.MappingProfiles;  
using AutoMapper;
using AlrightAPI.NewFolder;

namespace AlrightAPI.MappingProfiles  
{
    public class MappingProfile : Profile  // class declaration
    {
        public MappingProfile()  // constructor
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
        }
    }
}
