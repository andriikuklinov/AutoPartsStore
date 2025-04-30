namespace Category.API.Models.GetCategories
{
    public class GetCategoriesResponse
    {
        public IEnumerable<Category.API.Data.Entities.Category> Categories { get; private set; }

        public GetCategoriesResponse(IEnumerable<Category.API.Data.Entities.Category> categories)
        {
            Categories = categories;
        }
    }
}
