namespace Category.API.Categories.Commands.CreateCategory
{
    class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, CreateCategoryResult>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<CreateCategoryResult> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.CreateCategory(_mapper.Map<Category.API.Data.Entities.Category>(command))
                ?? throw new NullReferenceException("Create category operation returns null.");
            return _mapper.Map<CreateCategoryResult>(category);
        }
    }
}
