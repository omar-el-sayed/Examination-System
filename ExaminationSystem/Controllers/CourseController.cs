using ExaminationSystem.Services.Courses;
using ExaminationSystem.ViewModels.Course;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<CourseVM> GetAll()
            => _service.GetAll();

        [HttpGet("{id}")]
        public CourseVM GetById(int id)
            => _service.GetById(id);

        [HttpPost]
        public bool Add(CourseVM viewModel)
            => _service.Add(viewModel);

        [HttpPut("{id}")]
        public bool Update(int id, CourseVM viewModel)
            => _service.Update(id, viewModel);

        [HttpDelete("{id}")]
        public bool Delete(int id)
            => _service.Delete(id);

        [HttpGet]
        public int MinHours()
            => _service.Min();

        [HttpGet]
        public int MaxHours()
            => _service.Max();

        [HttpGet]
        public int Count()
            => _service.Count();
    }
}
