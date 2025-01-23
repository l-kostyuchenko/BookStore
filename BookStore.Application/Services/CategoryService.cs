using BookStore.Domain.DTOs.Category;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace BookStore.Application.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _repository;
		private readonly IMapper _mapper;
		private readonly ILogger<CategoryService> _logger;

		public CategoryService(ICategoryRepository repository, IMapper mapper, ILogger<CategoryService> logger)
		{
			_repository = repository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<List<CategoryDto>> GetAllCategoriesAsync(CancellationToken cancellationToken)
		{
			var categories = await _repository.GetAllAsync(cancellationToken);
			return _mapper.Map<List<CategoryDto>>(categories);
		}

		public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto, CancellationToken cancellationToken)
		{
			var category = _mapper.Map<Category>(createCategoryDto);

			var oldCategory = _repository.GetByCondition(x => x.Name == category.Name).FirstOrDefault();
			if (oldCategory != null)
			{
				_logger.LogError("Данная категория уже существует");
				throw new InvalidOperationException("Данная категория уже существует");
			}

			category = await _repository.CreateAsync(category, cancellationToken);

			_logger.LogInformation("Создана категория с ИД=" + category.Id);
			return _mapper.Map<CategoryDto>(category);
		}
	}
}
