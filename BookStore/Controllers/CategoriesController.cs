using Domain.DTOs.Category;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
		{
			var categories = await _categoryService.GetAllCategoriesAsync();
			return Ok(categories);
		}

		[HttpPost]
		public async Task<ActionResult<CategoryDto>> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
		{
			var createdCategory = await _categoryService.CreateCategoryAsync(createCategoryDto);
			return CreatedAtAction(nameof(GetCategories), new { id = createdCategory.Id }, createdCategory);
		}
	}
}
