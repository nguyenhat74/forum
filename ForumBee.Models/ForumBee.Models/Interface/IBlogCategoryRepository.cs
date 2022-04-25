using ForumITUDA.Models.Dto;
using ForumITUDA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumITUDA.Models.Interface
{
    public interface IBlogCategoryRepository
    {
        Task<BlogCategory> GetByIdAsync(Guid id);
        Task<IEnumerable<BlogCategory>> GetAllAsync();
        Task<BlogCategory> AddAsync(CreateBlogCategoryDto entity);
        Task<BlogCategory> UpdateAsync(UpdateBlogCategoryDto entity, Guid id);
        Task DeleteAsync(Guid id);
    }
}
