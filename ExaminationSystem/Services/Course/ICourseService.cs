using ExaminationSystem.ViewModels.Course;

namespace ExaminationSystem.Services.Courses
{
    public interface ICourseService
    {
        IEnumerable<CourseVM> GetAll();
        CourseVM GetById(int id);
        bool Add(CourseVM viewModel);
        bool Update(int id, CourseVM viewModel);
        bool Delete(int id);
        int Min();
        int Max();
        int Count();
    }
}
