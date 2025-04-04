using Asp.Versioning;
using BookStore.Domain.Dto.Category;
using BookStore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using SimpleResults;

namespace BookStore.WebApi.Controllers
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		/// <summary>
		/// Получить все категории
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<ListedResult<CategoryDto>> GetCategories(CancellationToken cancellationToken)
		{
			var categories = await _categoryService.GetAllCategoriesAsync(cancellationToken);
			return categories;
		}

		/// <summary>
		/// Создать новую категорию
		/// </summary>
		/// <param name="createCategoryDto"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<ActionResult<CategoryDto>> CreateCategory([FromBody] CreateCategoryDto createCategoryDto, CancellationToken cancellationToken)
		{
			var createdCategory = await _categoryService.CreateCategoryAsync(createCategoryDto, cancellationToken);
			return Ok(createdCategory);			
		}
	}
}
