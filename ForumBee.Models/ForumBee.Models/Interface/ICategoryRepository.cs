using ForumITUDA.Models.Dto;
using ForumITUDA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumITUDA.Models.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(Guid id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> AddAsync(CreateCategoryDto entity);
        Task<Category> UpdateAsync(UpdateCategoryDto entity, Guid id);
        Task DeleteAsync(Guid id);
    }
}
