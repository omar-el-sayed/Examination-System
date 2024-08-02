using ExaminationSystem.ViewModels.Exam;

namespace ExaminationSystem.Services.Exams
{
    public interface IExamService
    {
        IEnumerable<ExamVM> GetAll();
        ExamVM GetById(int id);
        bool Add(CreateExamVM viewModel);
        bool Update(int id, CreateExamVM viewModel);
        bool Delete(int id);
        int Min();
        int Max();
        int Count();
    }
}
