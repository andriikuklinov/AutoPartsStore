using Category.API.Data.Repositories.Contracts;

namespace Category.API.Categories.Queries.GetAllCategories
{
    class GetAllCategoriesHandler: IQueryHandler<GetAllCategoriesQuery, GetAllCategoriesResult>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<GetAllCategoriesResult> Handle(GetAllCategoriesQuery query, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllCategories();

            return new GetAllCategoriesResult(categories);
        }
    }
}
