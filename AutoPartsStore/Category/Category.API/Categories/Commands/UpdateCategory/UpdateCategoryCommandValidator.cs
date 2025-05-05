using FluentValidation;

namespace Category.API.Categories.Commands.UpdateCategory
{
    class UpdateCategoryCommandValidator: AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(category => category.Id).NotEqual(0).WithMessage("Id is required");
            RuleFor(category => category.Name).NotNull().NotEmpty().WithMessage("Name is required");
        }
    }
}
