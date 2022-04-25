using ForumITUDA.Models.Dto;
using ForumITUDA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumITUDA.Models.Interface
{
    public interface IBlogRepository
    {
        Task<Blog> GetByIdAsync(Guid id);
        Task<IEnumerable<Blog>> GetAllAsync();
        Task<Blog> AddAsync(CreateBlogDto entity);
        Task<Blog> UpdateAsync(UpdateBlogDto entity, Guid id);
        Task DeleteAsync(Guid id);

    }
}
