using ExaminationSystem.ViewModels.ExamQuestion;

namespace ExaminationSystem.Services.ExamQuestions
{
    public interface IExamQuestionService
    {
        void Add(CreateExamQuestionVM viewModel);
        void AddRange(IEnumerable<CreateExamQuestionVM> viewModels);
    }
}
