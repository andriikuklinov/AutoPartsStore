using Data.Common;
using Data.Common.Extensions;

namespace Category.API.Data.Repositories
{
    public class CategoryRepository: GenericRepository<Category.API.Data.Entities.Category, CategoryContext>, ICategoryRepository
    {
        private CategoryContext _context;
        public CategoryRepository(CategoryContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Entities.Category>> GetCategories(string filter, string orderBy, int page, int pageSize)
        {
            return await Get().Filter<Entities.Category>(filter).OrderBy<Entities.Category>(orderBy).Paginate(page, pageSize).ToListAsync<Entities.Category>();
        }
        public async Task<IEnumerable<Entities.Category>> GetAllCategories()
        {
            return await Get().ToListAsync<Entities.Category>();
        }
        public async Task<Entities.Category> CreateCategory(Entities.Category category)
        {
            return await AddAsync(category);
        }
        public async Task<Entities.Category> UpdateCategory(Entities.Category category)
        {
            return await UpdateAsync(category);
        }

        public async Task<Entities.Category> RemoveCategory(Entities.Category category)
        {
            return await DeleteAsync(category);
        }
    }
}