using ExaminationSystem.ViewModels.Student;

namespace ExaminationSystem.Services.Students
{
    public interface IStudentService
    {
        IEnumerable<StudentVM> GetAll();
        StudentVM GetById(int id);
        bool Add(CreateStudentVM viewModel);
        bool Update(int id, CreateStudentVM viewModel);
        bool Delete(int id);
        int Count();
    }
}
