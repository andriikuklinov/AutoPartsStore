using Category.API.Categories.Queries.GetAllCategories;

namespace Category.API.Categories.Queries.GetCategories
{
    class GetCategoriesResult:GetAllCategoriesResult
    {
        public GetCategoriesResult(IEnumerable<Category.API.Data.Entities.Category> categories):base(categories)
        {
        }
    }
}
