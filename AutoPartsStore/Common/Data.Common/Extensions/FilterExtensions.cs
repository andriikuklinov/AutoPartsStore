using Data.Common.Models;
using System.Globalization;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Data.Common.Extensions
{
    public static class FilterExtensions
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> query, string filter) where T : class
        {
            if (filter != null || filter.ToString() != string.Empty)
            {
                var filterData=new FilterData<string>();
                try
                {
                    filterData = JsonSerializer.Deserialize<FilterData<string>>(filter, new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true,
                        NumberHandling = JsonNumberHandling.AllowReadingFromString
                    });
                    if(filterData.Data==null)
                        throw new ArgumentException("Parameter filter is invalid (contain wrong json).", nameof(filter));
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Parameter filter is invalid (contain wrong json).", nameof(filter), ex);
                }
                var parameter = Expression.Parameter(typeof(T), "_");

                Expression filterExpression = null;
                foreach (var filterModel in filterData.Data)
                {
                    var property = Expression.Property(parameter, typeof(T), filterModel.PropertyName);
                    Type searchValueType = DetectSearchValueType(filterModel.Value);
                    var constant = Expression.Constant(Convert.ChangeType(filterModel.Value, searchValueType), searchValueType);
                    Expression comparison = null;
                    if (property.Type == typeof(string))
                    {
                        comparison = Expression.Call(property, "Contains", Type.EmptyTypes, constant);
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

        private static Type DetectSearchValueType(string value)
        {
            if (int.TryParse(value, CultureInfo.InvariantCulture, out _))
                return typeof(int);
            if (decimal.TryParse(value, CultureInfo.InvariantCulture, out _))
                return typeof(decimal);
            if (DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                return typeof(DateTime);
            return typeof(string);
        }
    }
}
