namespace Category.API.Models.CreateCategory
{
    public class CreateCategoryResponse
    {
        public Category.API.Data.Entities.Category Category { get; private set; }

        public CreateCategoryResponse(Category.API.Data.Entities.Category category)
        {
            Category = category;
        }
    }
}
