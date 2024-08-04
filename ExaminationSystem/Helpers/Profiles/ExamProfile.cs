using AutoMapper;
using ExaminationSystem.DTOs.Exam;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Exam;

namespace ExaminationSystem.Helpers.Profiles
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<CreateExamVM, CreateExamDto>();

            CreateMap<CreateExamDto, Exam>();

            CreateMap<Exam, ExamDto>()
                .ForMember(dst => dst.Instructor, opt => opt.MapFrom(src => $"{src.Instructor.FirstName} {src.Instructor.LastName}"))
                .ForMember(dst => dst.Course, opt => opt.MapFrom(src => src.Course.Name));

            CreateMap<ExamDto, ExamVM>();
        }
    }
}
