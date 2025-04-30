namespace Category.API.Categories.Commands.UpdateCategory
{
    class UpdateCategoryResult
    {
        public Category.API.Data.Entities.Category Category { get; private set; }

        public UpdateCategoryResult(Category.API.Data.Entities.Category category)
        {
            Category = category;
        }
    }
}
