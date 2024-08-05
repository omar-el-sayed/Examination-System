using ExaminationSystem.DTOs.Student;

namespace ExaminationSystem.Services.Students
{
    public interface IStudentService
    {
        IEnumerable<StudentDto> GetAll();
        StudentDto GetById(int id);
        bool Add(CreateStudentDto studentDto);
        bool Update(UpdateStudentDto studentDto);
        bool Delete(int id);
        int Count();
    }
}
