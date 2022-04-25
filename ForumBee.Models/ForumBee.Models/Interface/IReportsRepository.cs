using ForumITUDA.Models.Dto;
using ForumITUDA.Models.Entities;


namespace ForumITUDA.Models.Interface
{
    public interface IReportsRepository
    {
        Task<Report> GetByIdAsync(Guid id);
        Task<IEnumerable<Report>> GetAllAsync();
        Task<Report> AddAsync(CreateReportDto entity);
        Task<Report> UpdateAsync(UpdateReportDto entity, Guid id);
        Task DeleteAsync(Guid id);
    }
}
