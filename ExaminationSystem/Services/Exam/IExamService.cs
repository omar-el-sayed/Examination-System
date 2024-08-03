using ExaminationSystem.DTOs.Exam;
using ExaminationSystem.ViewModels.Exam;

namespace ExaminationSystem.Services.Exams
{
    public interface IExamService
    {
        IEnumerable<ExamVM> GetAll();
        ExamVM GetById(int id);
        bool Add(CreateExamDto examDto);
        bool Update(int id, CreateExamDto examDto);
        bool Delete(int id);
        int Min();
        int Max();
        int Count();
    }
}
