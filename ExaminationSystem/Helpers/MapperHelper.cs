using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace ExaminationSystem.Helpers
{
    public class MapperHelper<TResult>(IMapper mapper) : IMapperHelper<TResult>
    {
        public TResult Map(object source)
        {
            return mapper.Map<TResult>(source);
        }

        public IEnumerable<TResult> Map(IQueryable source)
        {
            return source.ProjectTo<TResult>(mapper.ConfigurationProvider);
        }
    }
}