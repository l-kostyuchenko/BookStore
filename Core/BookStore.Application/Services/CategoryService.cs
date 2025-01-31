using BookStore.Domain.Dto.Category;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Interfaces.Services;
using MapsterMapper;
using Serilog;
using SimpleResults;

namespace BookStore.Application.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _repository;
		private readonly IMapper _mapper;
		private readonly ILogger _logger;

		public CategoryService(ICategoryRepository repository, IMapper mapper, ILogger logger)
		{
			_repository = repository;
			_mapper = mapper;
			_logger = logger.ForContext<CategoryService>();
		}

		public async Task<ListedResult<CategoryDto>> GetAllCategoriesAsync(CancellationToken cancellationToken)
		{
			var categories = await _repository.GetAllAsync(cancellationToken);
			return Result.Success(_mapper.Map<List<CategoryDto>>(categories));
		}

		public async Task<Result<CategoryDto>> CreateCategoryAsync(CreateCategoryDto createCategoryDto, CancellationToken cancellationToken)
		{			
			var oldCategory = _repository.GetByCondition(x => x.Name == createCategoryDto.Name).FirstOrDefault();
			if (oldCategory != null)
			{
				_logger.Warning("Категория {oldCategoryName} уже существует", oldCategory.Name);
				return Result.Invalid($"Категория {oldCategory.Name} уже существует");
			}

			var category = _mapper.Map<Category>(createCategoryDto);
			category = await _repository.CreateAsync(category, cancellationToken);

			_logger.Information("Создана категория с ИД={categoryId}", category.Id);
			var dto = _mapper.Map<CategoryDto>(category);
			return Result.Success(dto);
		}
	}
}
