using ExaminationSystem.CQRS.Courses.Queries;
using ExaminationSystem.DTOs.Course;
using ExaminationSystem.Helpers;
using ExaminationSystem.Services.Courses;
using ExaminationSystem.ViewModels.Course;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(ICourseService _service, IMediator mediator) : ControllerBase
    {
        [HttpGet("getall")]
        public IEnumerable<CourseVM> GetAll()
            => _service.GetAll().AsQueryable().Map<CourseVM>();

        [HttpGet("getbyid/{id}")]
        public CourseVM GetById(int id)
            => _service.GetById(id).Map<CourseVM>();

        [HttpGet("getbyname")]
        public async Task<IEnumerable<CourseVM>> GetByName(string name)
        {
            var result = await mediator.Send(new GetCoursesByNameQuery(name));

            return result.Map<IEnumerable<CourseVM>>();
        }

        [HttpPost("add")]
        public bool Add(CreateCourseVM viewModel)
            => _service.Add(viewModel.Map<CreateCourseDto>());

        [HttpPut("update")]
        public bool Update(UpdateCourseVM viewModel)
            => _service.Update(viewModel.Map<UpdateCourseDto>());

        [HttpDelete("delete")]
        public bool Delete(int id)
            => _service.Delete(id);

        [HttpGet("min")]
        public int MinHours()
            => _service.Min();

        [HttpGet("max")]
        public int MaxHours()
            => _service.Max();

        [HttpGet("count")]
        public int Count()
            => _service.Count();
    }
}
