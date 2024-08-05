using ExaminationSystem.DTOs.Instructor;

namespace ExaminationSystem.Services.Instructors
{
    public interface IInstructorService
    {
        IEnumerable<InstructorDto> GetAll();
        IEnumerable<InstructorDto> Get();
        InstructorDto GetById(int id);
        bool Add(CreateInstructorDto instructorDto);
        bool Update(UpdateInstructorDto instructorDto);
        bool Delete(int id);
        double Min();
        double Max();
        int Count();
    }
}
