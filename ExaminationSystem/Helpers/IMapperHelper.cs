namespace ExaminationSystem.Helpers
{
    public interface IMapperHelper<TResult>
    {
        TResult Map(object source);
        IEnumerable<TResult> Map(IQueryable<TResult> source);
    }
}
