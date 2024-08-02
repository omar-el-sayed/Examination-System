using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using ExaminationSystem.ViewModels.Question;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IGenericRepository<Question> _repository;

        public QuestionController()
        {
            //_repository = new GenericRepository<Question>();
        }

        [HttpGet]
        public IEnumerable<QuestionVM> GetAll()
        {
            return _repository.GetAll().ToViewModel();
            //return _repository.GetAll().Select(q => new QuestionVM { Text = q.Text, Grade = q.Grade });
        }

        [HttpGet]
        public IEnumerable<QuestionVM> GetByCondition()
        {
            return _repository.Get(q => q.Grade <= 20).ToViewModel();
        }

        [HttpGet("{id}")]
        public QuestionVM GetById(int id)
        {
            var question = _repository.GetById(id);

            return question is not null ? question.ToViewModel() : new QuestionVM();
        }

        [HttpPost]
        public bool Add(QuestionVM viewModel)
        {
            var question = viewModel.ToModel();

            _repository.Add(question);
            _repository.SaveChanges();

            return true;
        }

        [HttpPut("{id}")]
        public bool Update(int id, QuestionVM viewModel)
        {
            var question = _repository.GetByIdWithTracking(id);

            if (question is null)
                return false;

            question.Text = viewModel.Text;
            question.Grade = viewModel.Grade;

            _repository.Update(question);
            _repository.SaveChanges();

            return true;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var question = _repository.GetByIdWithTracking(id);

            if (question is null)
                return false;

            _repository.Delete(question);
            _repository.SaveChanges();

            return true;
        }

        [HttpGet]
        public int MinGrade()
        {
            return _repository.Min(q => q.Grade);
        }

        [HttpGet]
        public int MaxGrade()
        {
            return _repository.Max(q => q.Grade);
        }

        [HttpGet]
        public int Count()
        {
            return _repository.Count();
        }
    }
}
