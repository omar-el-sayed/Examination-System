using AutoMapper;
using ExaminationSystem.DTOs.Question;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Question;

namespace ExaminationSystem.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, QuestionDto>();

            CreateMap<QuestionDto, QuestionVM>();

            CreateMap<CreateQuestionVM, CreateQuestionDto>();

            CreateMap<CreateQuestionDto, Question>();

            CreateMap<UpdateQuestionVM, UpdateQuestionDto>();

            CreateMap<UpdateQuestionDto, Question>();
        }
    }
}
