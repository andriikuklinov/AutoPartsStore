namespace Category.API.Categories.Commands.CreateCategory
{
    class CreateCategoryResult
    {
        public Category.API.Data.Entities.Category Category { get; private set; }

        public CreateCategoryResult(Category.API.Data.Entities.Category category)
        {
            Category = category;
        }
    }
}
