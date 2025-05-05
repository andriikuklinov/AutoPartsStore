using FluentValidation;

namespace Category.API.Categories.Commands.DeleteCategory
{
    class DeleteCategoryCommandValidator: AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(category => category.Id).NotEqual(0).WithMessage("Id is required");
        }
    }
}
