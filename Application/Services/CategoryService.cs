using AutoMapper;
using Domain.DTOs.Category;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _repository;
		private readonly IMapper _mapper;

		public CategoryService(ICategoryRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<List<CategoryDto>> GetAllCategoriesAsync()
		{
			var categories = await _repository.GetAllAsync();
			return _mapper.Map<List<CategoryDto>>(categories);
		}

		public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
		{
			var category = _mapper.Map<Category>(createCategoryDto);
			category = await _repository.CreateAsync(category);
			
			return _mapper.Map<CategoryDto>(category);
		}
	}
}
