using AutoMapper;
using ExaminationSystem.DTOs.Course;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Course;

namespace ExaminationSystem.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>();

            CreateMap<CourseDto, CourseVM>();

            CreateMap<CreateCourseVM, CreateCourseDto>();

            CreateMap<CreateCourseDto, Course>();

            CreateMap<UpdateCourseVM, UpdateCourseDto>();

            CreateMap<UpdateCourseDto, Course>();
        }
    }
}
