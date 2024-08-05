using ExaminationSystem.DTOs.Exam;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using ExaminationSystem.Services.ExamQuestions;

namespace ExaminationSystem.Services.Exams
{
    public class ExamService : IExamService
    {
        #region Fields
        private readonly IGenericRepository<Exam> _repository;
        private readonly IExamQuestionService _examQuestionService;
        #endregion

        #region Constructor
        public ExamService(IGenericRepository<Exam> repository, IExamQuestionService examQuestionService)
        {
            _repository = repository;
            _examQuestionService = examQuestionService;
        }
        #endregion

        #region Actions
        public IEnumerable<ExamDto> GetAll()
            => _repository.GetAll().Map<ExamDto>();
        {
            var exams = _repository.GetAll();

            return exams.Map<ExamDto>();
        }

    //public ExamDto GetById(int id)
    //{
    //    var exam = _repository.GetById(id);

    //    return exam is not null ? exam.ToViewModel() : new ExamVM();
    //}

    //public bool Add(CreateExamDto examDto)
    //{
    //    var exam = _repository.Add(viewModel.ToModel());
    //    _repository.SaveChanges();

    //    var examQuestions = new List<CreateExamQuestionVM>();

    //    foreach (var qId in viewModel.QuestionIds)
    //    {
    //        examQuestions.Add(new CreateExamQuestionVM
    //        {
    //            ExamId = exam.Id,
    //            QuestionId = qId
    //        });
    //    }

    //    _examQuestionService.AddRange(examQuestions);
    //    return true;
    //}

    //public bool Update(UpdateExamDto examDto)
    //{
    //    var exam = _repository.GetByIdWithTracking(examDto.Id);

    //    if (exam is null)
    //        return false;

    //    exam.StartDate = viewModel.StartDate;
    //    exam.TotalGrade = viewModel.TotalGrade;

    //    _repository.Update(exam);
    //    _repository.SaveChanges();

    //    return true;
    //}

    public bool Delete(int id)
    {
        var exam = _repository.GetByIdWithTracking(id);

        if (exam is null)
            return false;

        _repository.Delete(exam);
        _repository.SaveChanges();

        return true;
    }

    public int Min()
        => _repository.Min(e => e.TotalGrade);

    public int Max()
        => _repository.Max(e => e.TotalGrade);

    public int Count()
        => _repository.Count();
    #endregion
}
}
