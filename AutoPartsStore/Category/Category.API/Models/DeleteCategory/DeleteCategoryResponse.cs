namespace Category.API.Models.DeleteCategory
{
    public class DeleteCategoryResponse
    {
        public Category.API.Data.Entities.Category Category { get; private set; }

        public DeleteCategoryResponse(Category.API.Data.Entities.Category category)
        {
            Category = category;
        }
    }
}
