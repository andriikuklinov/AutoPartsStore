using AutoMapper;
using Category.API.Data.Repositories.Contracts;
using Common.CQRS;

namespace Category.API.Categories.Commands.DeleteCategory
{
    class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand, DeleteCategoryResult>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<DeleteCategoryResult> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.RemoveCategory(_mapper.Map<Category.API.Data.Entities.Category>(command))
                ?? throw new NullReferenceException("Delete category operation returns null.");
            return _mapper.Map<DeleteCategoryResult>(category);
        }
    }
}
