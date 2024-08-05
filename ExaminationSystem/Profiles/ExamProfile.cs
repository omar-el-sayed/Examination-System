using AutoMapper;
using ExaminationSystem.DTOs.Exam;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Exam;

namespace ExaminationSystem.Profiles
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<CreateExamVM, CreateExamDto>().ReverseMap();

            CreateMap<CreateExamDto, Exam>().ReverseMap();

            CreateMap<Exam, ExamDto>()
                .ForMember(dst => dst.Instructor, opt => opt.MapFrom(src => $"{src.Instructor.FirstName} {src.Instructor.LastName}"))
                .ForMember(dst => dst.Course, opt => opt.MapFrom(src => src.Course.Name))
                .ForMember(dst => dst.NumOfQuestions, opt => opt.MapFrom(src => src.ExamQuestions.Count));
            //.ForMember(dst => dst.TotalGrade, opt => opt.Ignore()); // To ignore a property

            CreateMap<ExamDto, ExamVM>();
        }
    }
}
