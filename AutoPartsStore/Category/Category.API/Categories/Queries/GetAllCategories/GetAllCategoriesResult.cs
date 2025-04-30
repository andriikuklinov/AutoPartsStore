namespace Category.API.Categories.Queries.GetAllCategories
{
    class GetAllCategoriesResult
    {
        public IEnumerable<Category.API.Data.Entities.Category> Categories { get; private set; }

        public GetAllCategoriesResult(IEnumerable<Category.API.Data.Entities.Category> categories)
        {
            Categories = categories;
        }
    }
}
