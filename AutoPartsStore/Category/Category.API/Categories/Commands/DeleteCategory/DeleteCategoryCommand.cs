using Common.CQRS;

namespace Category.API.Categories.Commands.DeleteCategory
{
    class DeleteCategoryCommand: Category.API.Data.Entities.Category, ICommand<DeleteCategoryResult>
    {
    }
}
