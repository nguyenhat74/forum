using ForumITUDA.Models.Dto;
using ForumITUDA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumITUDA.Models.Interface
{
    public interface IBlogTagRepository
    {
        Task<BlogTag> GetByIdAsync(Guid id);
        Task<IEnumerable<BlogTag>> GetAllAsync();
        Task<BlogTag> AddAsync(CreateBlogTagDto entity);
        Task<BlogTag> UpdateAsync(UpdateBlogTagDto entity, Guid id);
        Task DeleteAsync(Guid id);
    }
}
