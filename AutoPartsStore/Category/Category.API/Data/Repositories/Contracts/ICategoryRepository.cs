using Data.Common.Contracts;

namespace Category.API.Data.Repositories.Contracts
{
    public interface ICategoryRepository: IGenericRepository<Category.API.Data.Entities.Category>
    {
        Task<IEnumerable<Category.API.Data.Entities.Category>> GetCategories(string filter, string orderBy, int? page, int? pageSize);
        Task<IEnumerable<Category.API.Data.Entities.Category>> GetAllCategories();
        Task<Category.API.Data.Entities.Category> CreateCategory(Category.API.Data.Entities.Category category);
        Task<Category.API.Data.Entities.Category> UpdateCategory(Category.API.Data.Entities.Category category);
        Task<Category.API.Data.Entities.Category> RemoveCategory(Category.API.Data.Entities.Category category);
    }
}
