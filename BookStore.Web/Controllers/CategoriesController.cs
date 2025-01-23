using BookStore.Domain.DTOs.Category;
using BookStore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
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
		public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories(CancellationToken cancellationToken)
		{
			var categories = await _categoryService.GetAllCategoriesAsync(cancellationToken);
			return Ok(categories);
		}

		[HttpPost]
		public async Task<ActionResult<CategoryDto>> CreateCategory([FromBody] CreateCategoryDto createCategoryDto, CancellationToken cancellationToken)
		{
			try
			{
				var createdCategory = await _categoryService.CreateCategoryAsync(createCategoryDto, cancellationToken);
				return CreatedAtAction(nameof(GetCategories), new { id = createdCategory.Id }, createdCategory);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
