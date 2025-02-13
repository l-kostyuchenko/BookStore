using BookStore.Domain.Dto.Category;
using SimpleResults;

namespace BookStore.Domain.Interfaces.Services
{
	public interface ICategoryService
	{
		Task<ListedResult<CategoryDto>> GetAllCategoriesAsync(CancellationToken cancellationToken);
		Task<Result<CategoryDto>> CreateCategoryAsync(CreateCategoryDto createCategoryDto, CancellationToken cancellationToken);
	}
}
