using FluentValidation;

namespace Category.API.Categories.Commands.CreateCategory
{
    class CreateCategoryCommandValidator: AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(category => category.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
