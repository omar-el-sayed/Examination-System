using ExaminationSystem.DTOs.Question;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;

namespace ExaminationSystem.Services.Questions
{
    public class QuestionService(IGenericRepository<Question> _repository) : IQuestionService
    {
        public IEnumerable<QuestionDto> GetAll()
            => _repository.GetAll().Map<QuestionDto>();

        public IEnumerable<QuestionDto> Get()
            => _repository.Get(q => q.Grade < 100).Map<QuestionDto>();

        public QuestionDto GetById(int id)
        {
            var question = _repository.GetById(id);

            return question is not null ? question.Map<QuestionDto>() : new QuestionDto();
        }

        public bool Add(CreateQuestionDto questionDto)
        {
            var question = questionDto.Map<Question>();

            _repository.Add(question);
            _repository.SaveChanges();

            return true;
        }

        public bool Update(UpdateQuestionDto questionDto)
        {
            var question = _repository.GetByIdWithTracking(questionDto.Id);
            if (question is null)
                return false;

            question.Text = questionDto.Text;
            question.Grade = questionDto.Grade;

            _repository.Update(question);
            _repository.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var question = _repository.GetByIdWithTracking(id);
            if (question is null)
                return false;

            _repository.Delete(question);
            _repository.SaveChanges();

            return true;
        }

        public int Min()
            => _repository.Min(q => q.Grade);

        public int Max()
            => _repository.Max(q => q.Grade);

        public int Count()
            => _repository.Count();
    }
}
