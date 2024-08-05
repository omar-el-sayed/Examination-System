using ExaminationSystem.DTOs.Course;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;

namespace ExaminationSystem.Services.Courses
{
    public class CourseService(IGenericRepository<Course> _repository) : ICourseService
    {
        public IEnumerable<CourseDto> GetAll()
           => _repository.GetAll().Map<CourseDto>();

        public CourseDto GetById(int id)
        {
            var course = _repository.GetById(id);

            return course is not null ? course.Map<CourseDto>() : new CourseDto();
        }

        public bool Add(CreateCourseDto courseDto)
        {
            var course = courseDto.Map<Course>();

            _repository.Add(course);
            _repository.SaveChanges();

            return true;
        }

        public bool Update(UpdateCourseDto courseDto)
        {
            var course = _repository.GetByIdWithTracking(courseDto.Id);

            if (course is null)
                return false;

            course.Name = courseDto.Name;
            course.CreditHours = courseDto.CreditHours;

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
