using ExaminationSystem.Services.Exams;
using ExaminationSystem.ViewModels.Exam;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _service;

        public ExamController(IExamService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<ExamVM> GetAll()
            => _service.GetAll();

        [HttpGet("{id}")]
        public ExamVM GetById(int id)
            => _service.GetById(id);

        [HttpPost]
        public bool Add(CreateExamVM viewModel)
            => _service.Add(viewModel);

        [HttpPut("{id}")]
        public bool Update(int id, CreateExamVM viewModel)
            => _service.Update(id, viewModel);

        [HttpDelete("{id}")]
        public bool Delete(int id)
            => _service.Delete(id);

        [HttpGet]
        public int MinGrade()
            => _service.Min();

        [HttpGet]
        public int MaxGrade()
            => _service.Max();

        [HttpGet]
        public int Count()
            => _service.Count();
    }
}
