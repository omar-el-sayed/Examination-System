using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.CQRS.Courses.Queries
{
    public record GetCoursesByNameQuery(string Name) : IRequest<IEnumerable<CourseDTO>> { }

    public record CourseDTO(int Id, string Name);

    public class GetCoursesByNameQueryHandler : IRequestHandler<GetCoursesByNameQuery, IEnumerable<CourseDTO>>
    {
        private readonly IGenericRepository<Course> _repository;

        public GetCoursesByNameQueryHandler(IGenericRepository<Course> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CourseDTO>> Handle(GetCoursesByNameQuery request, CancellationToken cancellationToken)
        {
            var courses = await _repository.Get(c => c.Name.Contains(request.Name)).ToListAsync();

            return courses.Map<IEnumerable<CourseDTO>>();
        }
    }
}
