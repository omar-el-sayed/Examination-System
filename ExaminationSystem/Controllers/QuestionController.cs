using ExaminationSystem.DTOs.Question;
using ExaminationSystem.Helpers;
using ExaminationSystem.Services.Questions;
using ExaminationSystem.ViewModels.Question;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController(IQuestionService _service) : ControllerBase
    {
        [HttpGet("getall")]
        public IEnumerable<QuestionVM> GetAll()
            => _service.GetAll().AsQueryable().Map<QuestionVM>();

        [HttpGet("get")]
        public IEnumerable<QuestionVM> GetByCondition()
            => _service.Get().AsQueryable().Map<QuestionVM>();

        [HttpGet("getbyid/{id}")]
        public QuestionVM GetById(int id)
            => _service.GetById(id).Map<QuestionVM>();

        [HttpPost("add")]
        public bool Add(QuestionVM viewModel)
            => _service.Add(viewModel.Map<CreateQuestionDto>());

        [HttpPut("update")]
        public bool Update(UpdateQuestionVM viewModel)
            => _service.Update(viewModel.Map<UpdateQuestionDto>());

        [HttpDelete("delete/{id}")]
        public bool Delete(int id)
            => _service.Delete(id);

        [HttpGet("min")]
        public int MinGrade()
            => _service.Min();

        [HttpGet("max")]
        public int MaxGrade()
            => _service.Max();

        [HttpGet("count")]
        public int Count()
            => _service.Count();
    }
}
