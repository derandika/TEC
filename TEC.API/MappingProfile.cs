using AutoMapper;
using TEC.Domain.Dtos;
using TEC.Domain.Models;

namespace TEC.API
{
    /// <summary>
    /// Automapper mapping profile
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseUpdateDto, Course>();
        }
    }
}
