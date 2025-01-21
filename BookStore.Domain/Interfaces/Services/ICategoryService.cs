using BookStore.Domain.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces.Services
{
	public interface ICategoryService
	{
		Task<List<CategoryDto>> GetAllCategoriesAsync();
		Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
	}
}
