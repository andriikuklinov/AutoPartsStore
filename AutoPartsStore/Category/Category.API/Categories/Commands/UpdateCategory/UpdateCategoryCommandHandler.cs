namespace Category.API.Categories.Commands.UpdateCategory
{
    class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, UpdateCategoryResult>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<UpdateCategoryResult> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.UpdateCategory(_mapper.Map<Category.API.Data.Entities.Category>(command))
                ?? throw new NullReferenceException("Update category operation returns null.");
            return _mapper.Map<UpdateCategoryResult>(category);
        }
    }
}
