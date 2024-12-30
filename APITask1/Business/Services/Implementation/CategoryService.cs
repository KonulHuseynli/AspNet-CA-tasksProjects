using Business.DTOs.Category.Request;
using Business.DTOs.Category.Response;
using Business.Services.Abstraction;
using Business.Validator.Category;
using Core.Entities;
using DataAccess.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Response<CategoryResponseDTO>> GetAllAsync()
        {
            var response = new Response<CategoryResponseDTO>()
            {
                Data = new CategoryResponseDTO
                {
                    Categories = await _categoryRepository.GetAllAsync()
                }
            };

            return response;
        }

        public async Task<Response<CategoryItemResponseDTO>> GetAsync(int id)
        {
            var response = new Response<CategoryItemResponseDTO>();

            var category = await _categoryRepository.GetAsync(id);
            if (category == null)
            {
                response.Errors.Add("Kateqoriya tapılmadı");
                response.Status = StatusCode.NotFound;
                return response;
            }

            response.Data = new CategoryItemResponseDTO
            {
                Category = category
            };

            return response;
        }

        public async Task<Response> CreateAsync(CategoryCreateDto model)
        {
            var response = new Response();
            CategoryCreateDTOValidator validator = new CategoryCreateDTOValidator();
            var result = validator.Validate(model);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                    response.Errors.Add(error.ErrorMessage);

                response.Status = StatusCode.BadRequest;
                return response;
            }

            var isExist = await _categoryRepository.AnyAsync(c => c.Title.ToLower().Trim() == model.Title.ToLower().Trim());
            if (isExist)
            {
                response.Errors.Add("Bu adda kateqoriya artıq mövcuddur");
                response.Status = StatusCode.BadRequest;
                return response;
            }

            var category = new Category
            {
                Title = model.Title,
                CreatedAt = DateTime.Now
            };

            await _categoryRepository.CreateAsync(category);
            return response;
        }

        public async Task<Response> UpdateAsync(CategoryUpdateDTO model)
        {
            var response = new Response();
            var validator = new CategoryUpdateDTOValidator();
            var result = validator.Validate(model);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                    response.Errors.Add(error.ErrorMessage);

                response.Status = StatusCode.BadRequest;
                return response;
            }

            var isExist = await _categoryRepository.AnyAsync(c => c.Title.ToLower().Trim() == model.Title.ToLower().Trim() && c.Id != model.Id);
            if (isExist)
            {
                response.Errors.Add("Bu adda kateqoriya artıq mövcuddur");
                response.Status = StatusCode.BadRequest;
                return response;
            }

            var category = await _categoryRepository.GetAsync(model.Id);
            if (category == null)
            {
                response.Errors.Add("Kateqoriya tapılmadı");
                response.Status = StatusCode.NotFound;
                return response;
            }

            category.Title = model.Title;

            await _categoryRepository.UpdateAsync(category);
            return response;
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response();

            var category = await _categoryRepository.GetAsync(id);
            if (category == null)
            {
                response.Errors.Add("Kateqoriya tapılmadı");
                response.Status = StatusCode.NotFound;
                return response;
            }

            await _categoryRepository.DeleteAsync(category);
            return response;
        }
    }
}
