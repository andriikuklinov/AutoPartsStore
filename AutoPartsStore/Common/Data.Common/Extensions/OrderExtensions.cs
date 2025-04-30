using Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data.Common.Extensions
{
    public static class OrderExtensions
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string order) where T : class
        {
            if (string.IsNullOrEmpty(order))
                throw new ArgumentException("Parameter order is null or empty", nameof(order));
            var orderData = new OrderData();
            try
            {
                orderData = JsonSerializer.Deserialize<OrderData>(order, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                if (orderData.Data == null)
                    throw new NullReferenceException("Orderdata is null");
            }
            catch (JsonException ex)
            {
                throw new ArgumentException("Parameter order is invalid (contain wrong json).", nameof(order));
            }
            catch (NullReferenceException ex)
            {
                throw new ArgumentException("Parameter order is invalid (contain wrong json).", nameof(order));
            }
            var parameter = Expression.Parameter(typeof(T), "_");

            string method = string.Empty;
            foreach (var orderModel in orderData.Data)
            {
                var property = Expression.Property(parameter, orderModel.PropertyName);
                var lambda = Expression.Lambda(property, parameter);
                if (string.IsNullOrEmpty(method))
                {
                    method = orderModel.Direction == "asc" ? "OrderBy" : "OrderByDescending";
                }
                else
                {
                    method = orderModel.Direction == "asc" ? "ThenBy" : "ThenByDescending";
                }
                Type[] types = new Type[] { typeof(T), lambda.Body.Type };
                var methodCallExpression = Expression.Call(typeof(Queryable), method, types, query.Expression, lambda);

                query = query.Provider.CreateQuery<T>(methodCallExpression);
            }
            return query;
        }
    }
}
