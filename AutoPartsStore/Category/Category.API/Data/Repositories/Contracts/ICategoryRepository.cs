using Data.Common.Contracts;

namespace Category.API.Data.Repositories.Contracts
{
    public interface ICategoryRepository: IGenericRepository<Category.API.Data.Entities.Category>
    {
        Task<IEnumerable<Category.API.Data.Entities.Category>> GetCategories(string filter, string orderBy, int? page, int? pageSize);
    }
}
