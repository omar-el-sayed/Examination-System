﻿using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace ExaminationSystem.Helpers
{
    public static class MapperHelper
    {
        public static IMapper Mapper { get; set; }

        public static TResult Map<TResult>(this object source)
        {
            return Mapper.Map<TResult>(source);
        }

        public static IEnumerable<TResult> Map<TResult>(this IQueryable source)
        {
            return source.ProjectTo<TResult>(Mapper.ConfigurationProvider);
        }
    }
}