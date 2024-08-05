using ExaminationSystem.DTOs.Course;

namespace ExaminationSystem.Services.Courses
{
    public interface ICourseService
    {
        IEnumerable<CourseDto> GetAll();
        CourseDto GetById(int id);
        bool Add(CreateCourseDto courseDto);
        bool Update(UpdateCourseDto courseDto);
        bool Delete(int id);
        int Min();
        int Max();
        int Count();
    }
}
