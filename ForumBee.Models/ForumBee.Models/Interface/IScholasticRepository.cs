using ForumITUDA.Models.Dto;
using ForumITUDA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumITUDA.Models.Interface
{
    public interface IScholasticRepository
    {
        Task<Scholastic> GetByIdAsync(Guid id);
        Task<IEnumerable<Scholastic>> GetAllAsync();
        Task<Scholastic> AddAsync(CreateScholasticDto entity);
        Task<Scholastic> UpdateAsync(UpdateScholasticDto entity, Guid id);
        Task DeleteAsync(Guid id);
    }
}
