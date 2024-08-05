using ExaminationSystem.DTOs.Student;
using ExaminationSystem.Helpers;
using ExaminationSystem.Services.Students;
using ExaminationSystem.ViewModels.Student;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentService _service) : ControllerBase
    {
        [HttpGet("get")]
        public IEnumerable<StudentVM> GetAll()
            => _service.GetAll().AsQueryable().Map<StudentVM>();

        [HttpGet("getbyid/{id}")]
        public StudentVM GetById(int id)
            => _service.GetById(id).Map<StudentVM>();

        [HttpPost("add")]
        public bool Add(CreateStudentVM viewModel)
            => _service.Add(viewModel.Map<CreateStudentDto>());

        [HttpPut("update")]
        public bool Update(UpdateStudentVM viewModel)
            => _service.Update(viewModel.Map<UpdateStudentDto>());

        [HttpDelete("delete/{id}")]
        public bool Delete(int id)
                => _service.Delete(id);

        [HttpGet("count")]
        public int Count()
            => _service.Count();
    }
}
