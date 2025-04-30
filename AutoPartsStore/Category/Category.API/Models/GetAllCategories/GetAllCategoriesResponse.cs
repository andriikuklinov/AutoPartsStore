namespace Category.API.Models.GetAllCategories
{
    public class GetAllCategoriesResponse: GetCategoriesResponse
    {
        public GetAllCategoriesResponse(IEnumerable<Category.API.Data.Entities.Category> categories):base(categories)
        {
            
        }
    }
}
