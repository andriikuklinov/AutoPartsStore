namespace Category.API.Models.UpdateCategory
{
    public class UpdateCategoryResponse
    {
        public Category.API.Data.Entities.Category Category { get; private set; }

        public UpdateCategoryResponse(Category.API.Data.Entities.Category category)
        {
            Category = category;
        }
    }
}
