
namespace Data.Common.Extensions
{
    public static class PaginationExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int pageIndex=0, int pageSize=10) where T : class
        {
            if (pageIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(pageIndex), pageIndex, "Invalid pageIndex value.");
            else if (pageSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "Invalid pageSize value.");
            else
                return query.Skip(pageIndex * pageSize).Take(pageSize);
        }
    }
}
