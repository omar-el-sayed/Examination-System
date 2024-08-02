using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using ExaminationSystem.ViewModels.ExamQuestion;

namespace ExaminationSystem.Services.ExamQuestions
{
    public class ExamQuestionService : IExamQuestionService
    {
        private readonly IGenericRepository<ExamQuestion> _repository;

        public ExamQuestionService(IGenericRepository<ExamQuestion> repository)
        {
            _repository = repository;
        }

        public void Add(CreateExamQuestionVM viewModel)
        {
            _repository.Add(viewModel.ToModel());

            _repository.SaveChanges();
        }

        public void AddRange(IEnumerable<CreateExamQuestionVM> viewModels)
        {
            foreach (var viewModel in viewModels)
            {
                _repository.Add(viewModel.ToModel());
            }

            _repository.SaveChanges();
        }
    }
}
