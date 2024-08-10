using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExaminationSystem.DTOs.Exam;
using ExaminationSystem.Helpers;
using ExaminationSystem.Services.Exams;
using ExaminationSystem.Services.Instructors;
using ExaminationSystem.ViewModels.Exam;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamController(IExamService _service, IInstructorService _instructorService, IMapper _mapper) : ControllerBase
    {
        [HttpGet("getall")]
        public IEnumerable<ExamVM> GetAll()
        {
            //return _mapper.Map<IEnumerable<ExamVM>>(_service.GetAll());
            //return _service.GetAll().Select(e => _mapper.Map<ExamVM>(e));
            return _service.GetAll()
                .AsQueryable()
                .ProjectTo<ExamVM>(_mapper.ConfigurationProvider);
        }

        [HttpGet("{id}")]
        public ExamVM GetById(int id)
            => _service.GetById(id).Map<ExamVM>();

        [HttpPost("add")]
        public bool Add(CreateExamVM viewModel)
        {
            _service.Add(viewModel.Map<CreateExamDto>());

            _instructorService.IncreasePoints(viewModel.InstructorId);

            return true;
        }

        //[HttpPut("{id}")]
        //public bool Update(int id, CreateExamVM viewModel)
        //    => _service.Update(id, viewModel);

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
