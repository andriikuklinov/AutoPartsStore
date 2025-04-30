using Category.API.Data.Repositories.Contracts;
using Common.CQRS;

namespace Category.API.Categories.Queries.GetCategories
{
    class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, GetCategoriesResult>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<GetCategoriesResult> Handle(GetCategoriesQuery query, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetCategories(query.Filter, query.OrderBy, query.Page, query.PageSize);

            return new GetCategoriesResult(categories);
        }
    }
}
