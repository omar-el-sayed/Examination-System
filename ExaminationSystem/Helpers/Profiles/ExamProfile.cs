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
        }
    }
}
