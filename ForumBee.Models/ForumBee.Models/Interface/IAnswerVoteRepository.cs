using ForumITUDA.Models.Dto;
using ForumITUDA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumITUDA.Models.Interface
{
    public interface IAnswerVoteRepository
    {
        Task<AnswerVote> GetByIdAsync(Guid id);
        Task<IEnumerable<AnswerVote>> GetAllAsync();
        Task<AnswerVote> AddAsync(CreateAnswerVoteDto entity);
        Task<AnswerVote> UpdateAsync(UpdateAnswerVoteDto entity, Guid id);
        Task DeleteAsync(Guid id);
    }
}
