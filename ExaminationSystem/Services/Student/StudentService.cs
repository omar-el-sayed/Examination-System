using ExaminationSystem.DTOs.Student;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;

namespace ExaminationSystem.Services.Students
{
    public class StudentService(IGenericRepository<Student> _repository) : IStudentService
    {
        public IEnumerable<StudentDto> GetAll()
           => _repository.GetAll().Map<StudentDto>();

        public StudentDto GetById(int id)
        {
            var student = _repository.GetById(id);

            return student is not null ? student.Map<StudentDto>() : new StudentDto();
        }

        public bool Add(CreateStudentDto studentDto)
        {
            var student = studentDto.Map<Student>();

            _repository.Add(student);
            _repository.SaveChanges();

            return true;
        }

        public bool Update(UpdateStudentDto studentDto)
        {
            var student = _repository.GetByIdWithTracking(studentDto.Id);

            if (student is null)
                return false;

            student.FirstName = studentDto.FirstName;
            student.LastName = studentDto.LastName;

            _repository.Update(student);
            _repository.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var student = _repository.GetByIdWithTracking(id);

            if (student is null)
                return false;

            _repository.Delete(student);
            _repository.SaveChanges();

            return true;
        }

        public int Count()
            => _repository.Count();
    }
}
