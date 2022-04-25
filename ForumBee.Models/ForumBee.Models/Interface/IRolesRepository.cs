using ForumITUDA.Models.Dto;
using ForumITUDA.Models.Entities;

namespace ForumITUDA.Models.Interface
{
    public interface IRolesRepository
    {
        Task<Role> GetByIdAsync(Guid id);
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> AddAsync(CreateRoleDto entity);
        Task<Role> UpdateAsync(UpdateRoleDto entity, Guid id);
        Task DeleteAsync(Guid id);
    }
}
