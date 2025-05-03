
namespace Data.Common.Extensions
{
    public static class PaginationExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int? pageIndex, int? pageSize) where T : class
        {
            if (pageIndex == null || pageSize == null)
                return query;
            return query.Skip((int)pageIndex * (int)pageSize).Take((int)pageSize);
        }
    }
}
