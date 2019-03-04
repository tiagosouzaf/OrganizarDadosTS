using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OrganizarDadosTS
{
   public static class MapperExtension
    {
        public static T Map<T>(this T obj) where T : class
        {
            return Mapper.Map<T>(obj);
        }

        public static IQueryable<TDestination> Map<TDestination>(this IQueryable source, object parameters,
            params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(parameters, membersToExpand);
        }

        public static IQueryable<TDestination> Map<TDestination>(this IQueryable source,
            IConfigurationProvider configuration, object parameters,
            params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(configuration, parameters, membersToExpand);
        }

        public static IQueryable<TDestination> Map<TDestination>(this IQueryable source,
            IConfigurationProvider configuration, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(configuration, membersToExpand);
        }

        public static IQueryable<TDestination> Map<TDestination>(this IQueryable source,
            params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(membersToExpand);

        }

        public static IQueryable<TDestination> Map<TDestination>(this IQueryable source,
            IDictionary<string, object> parameters, params string[] membersToExpand)
        {
            return source.ProjectTo<TDestination>(parameters, membersToExpand);
        }


        public static IQueryable<TDestination> Map<TDestination>(this IQueryable source,
            IConfigurationProvider configuration, IDictionary<string, object> parameters,
            params string[] membersToExpand)
        {
            return source.ProjectTo<TDestination>(configuration, parameters, membersToExpand);
        }
    }
}
