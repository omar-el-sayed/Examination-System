using ExaminationSystem.DTOs.Exam;

namespace ExaminationSystem.Services.Exams
{
    public interface IExamService
    {
        IEnumerable<ExamDto> GetAll();
        //ExamDto GetById(int id);
        //bool Add(CreateExamDto examDto);
        //bool Update(UpdateExamDto examDto);
        bool Delete(int id);
        int Min();
        int Max();
        int Count();
    }
}
