using ExaminationSystem.Services.Students;
using ExaminationSystem.ViewModels.Student;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<StudentVM> GetAll()
            => _service.GetAll();

        [HttpGet("{id}")]
        public StudentVM GetById(int id)
            => _service.GetById(id);

        [HttpPost]
        public bool Add(CreateStudentVM viewModel)
            => _service.Add(viewModel);

        [HttpPut("{id}")]
        public bool Update(int id, CreateStudentVM viewModel)
            => _service.Update(id, viewModel);

        [HttpDelete("{id}")]
        public bool Delete(int id)
                => _service.Delete(id);

        [HttpGet]
        public int Count()
            => _service.Count();
    }
}
