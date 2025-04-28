using Data.Common.Models;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Data.Common.Extensions
{
    public static class FilterExtensions
    {
        public static IQueryable<T> Filter<T, TFilterValue>(this IQueryable<T> query, string filter)
        {
            if(filter != null || filter.ToString() != string.Empty)
            {
                var filterData = JsonSerializer.Deserialize<FilterData<TFilterValue>>(filter, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive=true,
                    NumberHandling=JsonNumberHandling.AllowReadingFromString
                });
                var parameter = Expression.Parameter(typeof(T), "_");

                Expression filterExpression = null;
                foreach(var filterModel in filterData.Data)
                {
                    var property = Expression.Property(parameter, filterModel.PropertyName);
                    var constant = Expression.Constant(filterModel.Value, typeof(TFilterValue));
                    Expression comparison = null;
                    if(property.Type == typeof(string))
                    {
                        comparison=Expression.Call(property, "Contains", Type.EmptyTypes, constant);
                    }
                    else
                    {
                        comparison = Expression.Equal(property, constant);
                    }
                    filterExpression = filterExpression == null ? comparison : Expression.Add(filterExpression, comparison);
                }
                var lambda = Expression.Lambda<Func<T, bool>>(filterExpression, parameter);

                return query.Where(lambda);
            }
            return query;
        }
    }
}
