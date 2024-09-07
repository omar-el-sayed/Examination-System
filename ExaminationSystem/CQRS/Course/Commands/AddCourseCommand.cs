using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using MediatR;

namespace ExaminationSystem.CQRS.Courses.Commands
{
    public record AddCourseCommand(string name, int hours, int instructorId) : IRequest<bool>;

    public class AddCourseCommandHandler : IRequestHandler<AddCourseCommand, bool>
    {
        private readonly IGenericRepository<Course> _repository;

        public AddCourseCommandHandler(IGenericRepository<Course> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            var course = request.Map<Course>();

            await Task.Run(() => _repository.Add(course));
            _repository.SaveChanges();

            return true;
        }
    }
}
