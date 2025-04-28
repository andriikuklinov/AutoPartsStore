using Category.API.Data.Repositories.Contracts;
using Data.Common;

namespace Category.API.Data.Repositories
{
    public class CategoryRepository: GenericRepository<Category.API.Data.Entities.Category, CategoryContext>, ICategoryRepository
    {
        private CategoryContext _context;
        public CategoryRepository(CategoryContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Entities.Category>> GetCategories(string filter, string orderBy, int? page, int? pageSize)
        {
            return await Get().Filter(filter).OrderBy(orderBy).Paginate(page, pageSize).ToListAsync<Entities.Category>();
        }
    }
}
