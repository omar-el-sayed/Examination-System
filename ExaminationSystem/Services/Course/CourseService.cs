using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using ExaminationSystem.ViewModels.Course;

namespace ExaminationSystem.Services.Courses
{
    public class CourseService : ICourseService
    {
        private readonly IGenericRepository<Course> _repository;

        public CourseService(IGenericRepository<Course> repository)
        {
            _repository = repository;
        }

        public IEnumerable<CourseVM> GetAll()
           => _repository.GetAll().ToViewModel();

        public CourseVM GetById(int id)
        {
            var course = _repository.GetById(id);

            return course is not null ? course.ToViewModel() : new CourseVM();
        }

        public bool Add(CourseVM viewModel)
        {
            var course = viewModel.ToModel();

            _repository.Add(course);
            _repository.SaveChanges();

            return true;
        }

        public bool Update(int id, CourseVM viewModel)
        {
            var course = _repository.GetByIdWithTracking(id);

            if (course is null)
                return false;

            course.Name = viewModel.Name;
            course.CreditHours = viewModel.CreditHours;

            _repository.Update(course);
            _repository.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var course = _repository.GetByIdWithTracking(id);

            if (course is null)
                return false;

            _repository.Delete(course);
            _repository.SaveChanges();

            return true;
        }

        public int Min()
            => _repository.Min(e => e.CreditHours);

        public int Max()
            => _repository.Max(e => e.CreditHours);

        public int Count()
            => _repository.Count();
    }
}
