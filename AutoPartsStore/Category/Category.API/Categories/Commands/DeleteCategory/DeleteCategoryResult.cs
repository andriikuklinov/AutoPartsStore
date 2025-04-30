namespace Category.API.Categories.Commands.DeleteCategory
{
    class DeleteCategoryResult
    {
        public Category.API.Data.Entities.Category Category { get; private set; }

        public DeleteCategoryResult(Category.API.Data.Entities.Category category)
        {
            Category = category;
        }
    }
}
