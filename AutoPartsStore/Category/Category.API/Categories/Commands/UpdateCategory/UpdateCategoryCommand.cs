using Common.CQRS;

namespace Category.API.Categories.Commands.UpdateCategory
{
    class UpdateCategoryCommand: Category.API.Data.Entities.Category, ICommand<UpdateCategoryResult>
    {
    }
}
