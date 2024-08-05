using ExaminationSystem.DTOs.Question;

namespace ExaminationSystem.Services.Questions
{
    public interface IQuestionService
    {
        IEnumerable<QuestionDto> GetAll();
        IEnumerable<QuestionDto> Get();
        QuestionDto GetById(int id);
        bool Add(CreateQuestionDto questionDto);
        bool Update(UpdateQuestionDto questionDto);
        bool Delete(int id);
        int Min();
        int Max();
        int Count();
    }
}
