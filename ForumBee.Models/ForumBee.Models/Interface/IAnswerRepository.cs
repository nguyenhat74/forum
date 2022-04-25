using ForumITUDA.Models.Dto;
using ForumITUDA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumITUDA.Models.Interface
{
    public interface IAnswerRepository
    {
        Task<Answer> GetByIdAsync(Guid id);
        Task<IEnumerable<Answer>> GetAllAsync();
        Task<Answer> AddAsync(CreateAnswerDto entity);
        Task<Answer> UpdateAsync(UpdateAnswerDto entity, Guid id);
        Task DeleteAsync(Guid id);
    }
}
