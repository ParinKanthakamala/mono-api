using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Shared.Libraries.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TSource> SelectProperties<TSource>(this IQueryable<TSource> sources,
            ISet<string> propertiesToSelect)
        {
            if (sources == null) throw new ArgumentNullException(nameof(sources));
            if (propertiesToSelect == null) throw new ArgumentNullException(nameof(propertiesToSelect));
// Check if properties exist in TSource
            var properties = typeof(TSource).GetProperties().Where(p => propertiesToSelect.Contains(p.Name))
                .Select(p => p.Name);
            if (!properties.Any())
                throw new ArgumentException("Specified properties not found", nameof(propertiesToSelect));
            var type = typeof(TSource);
            // p =>
            var parameter = Expression.Parameter(type, "p");
            // create bindings for initialization
            var bindings = properties
                .Select(s =>
                    {
                        // property
                        var property = type.GetProperty(s);
                        // original value 
                        var propertyExpression = Expression.Property(parameter, property);
                        // set value "Property = p.Property"
                        return Expression.Bind(property, propertyExpression);
                    }
                );
            // new TSource()
            var newViewModel = Expression.New(type);
            // new TSource { Property1 = p.Property1, ... }
            var body = Expression.MemberInit(newViewModel, bindings);
            // p => new TSource { Property1 = p.Property1, ... }
            var selector = Expression.Lambda<Func<TSource, TSource>>(body, parameter);
            return sources.Select(selector);
        }

        public static IQueryable<TSource> SelectProperties<TSource>(this IQueryable<TSource> sources,
            string propertiesToSelect)
        {
            if (sources == null) throw new ArgumentNullException(nameof(sources));
            if (propertiesToSelect == null) throw new ArgumentNullException(nameof(propertiesToSelect));
            var names = new HashSet<string>();
            var properties = propertiesToSelect.Split(',');
            foreach (var p in properties) names.Add(p);

            return sources.SelectProperties(names);
        }
    }
}