using Business.DTOs.Category.Request;
using Business.DTOs.Category.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstraction
{
    public interface ICategoryService
    {
        Task<Response<CategoryResponseDTO>> GetAllAsync();
        Task<Response<CategoryItemResponseDTO>> GetAsync(int id);
        Task<Response> CreateAsync(CategoryCreateDto model);
        Task<Response> UpdateAsync(CategoryUpdateDTO model);
        Task<Response> DeleteAsync(int id);

    }
}
