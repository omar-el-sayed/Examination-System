using ExaminationSystem.DTOs.Instructor;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;

namespace ExaminationSystem.Services.Instructors
{
    public class InstructorService(IGenericRepository<Instructor> repository) : IInstructorService
    {
        public IEnumerable<InstructorDto> GetAll()
            => repository.GetAll().Map<InstructorDto>();

        public IEnumerable<InstructorDto> Get()
            => repository.Get(i => i.Id < 100).Map<InstructorDto>();

        public InstructorDto GetById(int id)
        {
            var instructor = repository.GetById(id);

            return instructor is not null ? instructor.Map<InstructorDto>() : new InstructorDto();
        }

        public bool Add(CreateInstructorDto instructorDto)
        {
            var instructor = instructorDto.Map<Instructor>();

            repository.Add(instructor);
            repository.SaveChanges();

            return true;
        }

        public bool Update(UpdateInstructorDto instructorDto)
        {
            var instructor = repository.GetByIdWithTracking(instructorDto.Id);

            if (instructor is null)
                return false;

            instructor.FirstName = instructorDto.FirstName;
            instructor.LastName = instructorDto.LastName;
            instructor.Salary = instructorDto.Salary;

            repository.Update(instructor);
            repository.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var instructor = repository.GetByIdWithTracking(id);

            if (instructor is null)
                return false;

            repository.Delete(instructor);
            repository.SaveChanges();

            return true;
        }

        public double Min()
            => repository.Min(i => Convert.ToInt32(i.Salary));

        public double Max()
            => repository.Max(i => Convert.ToInt32(i.Salary));

        public int Count()
            => repository.Count();
    }
}
