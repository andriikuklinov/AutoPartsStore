namespace Category.API.Categories.Queries.GetAllCategories
{
    class GetAllCategoriesQueryHandler: IQueryHandler<GetAllCategoriesQuery, GetAllCategoriesResult>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
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
