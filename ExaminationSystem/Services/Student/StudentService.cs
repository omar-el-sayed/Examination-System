using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using ExaminationSystem.ViewModels.Student;

namespace ExaminationSystem.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> _repository;

        public StudentService(IGenericRepository<Student> repository)
        {
            _repository = repository;
        }

        public IEnumerable<StudentVM> GetAll()
           => _repository.GetAll().ToViewModel();

        public StudentVM GetById(int id)
        {
            var student = _repository.GetById(id);

            return student is not null ? student.ToViewModel() : new StudentVM();
        }

        public bool Add(CreateStudentVM viewModel)
        {
            var student = viewModel.ToModel();

            _repository.Add(student);
            _repository.SaveChanges();

            return true;
        }

        public bool Update(int id, CreateStudentVM viewModel)
        {
            var student = _repository.GetByIdWithTracking(id);

            if (student is null)
                return false;

            student.FirstName = viewModel.FirstName;
            student.LastName = viewModel.LastName;

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
