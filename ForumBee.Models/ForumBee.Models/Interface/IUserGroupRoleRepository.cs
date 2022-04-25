using ForumITUDA.Models.Dto;
using ForumITUDA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumITUDA.Models.Interface
{
    public interface IUserGroupRoleRepository
    {
        Task<UserGroupRole> GetByIdAsync(Guid id);
        Task<IEnumerable<UserGroupRole>> GetAllAsync();
        Task<UserGroupRole> AddAsync(CreateUserGroupRoleDto entity);
        Task<UserGroupRole> UpdateAsync(UpdateUserGroupRoleDto entity, Guid id);
        Task DeleteAsync(Guid id);
    }
}
