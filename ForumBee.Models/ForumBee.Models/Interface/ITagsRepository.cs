using ForumITUDA.Models.Dto;
using ForumITUDA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumITUDA.Models.Interface
{
    public interface ITagsRepository
    {
        Task<Tag> GetByIdAsync(Guid id);
        Task<IEnumerable<Tag>> GetAllAsync();
        Task<Tag> AddAsync(CreateTagDto entity);
        Task<Tag> UpdateAsync(UpdateTagDto entity, Guid id);
        Task DeleteAsync(Guid id);
    }
}
