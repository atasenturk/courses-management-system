using AutoMapper;
using LMS.Web.API.DTO;
using LMS.Web.API.Models;

namespace LMS.Web.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AddStudentDTO, Student>().ReverseMap();
            CreateMap<AddCourseDTO, Course>().ReverseMap();
            CreateMap<CoursesOfStudentDTO, Course>().ReverseMap();
        }
    }
}
