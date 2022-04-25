using Dapper;
using ForumITUDA.Models.Dto;
using ForumITUDA.Models.Entities;
using ForumITUDA.Models.Interface;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ForumITUDA.Models.Repository
{
    public class UserGroupRoleRepository : IUserGroupRoleRepository
    {
        private readonly IConfiguration configuration;
        public UserGroupRoleRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<UserGroupRole> AddAsync(CreateUserGroupRoleDto entity)
        {
            var procedureName = "spCreateUserGroupRoles";
            var parameters = new DynamicParameters();
            parameters.Add("GroupId", entity.GroupId, DbType.Guid, ParameterDirection.Input);
            parameters.Add("RoleId", entity.RoleId, DbType.Guid, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.String, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<UserGroupRole>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var userGroupRole = new UserGroupRole()
                {
                    GroupId = entity.GroupId,
                    RoleId = entity.RoleId,
                    IsActive = entity.IsActive,                  
                };
                return userGroupRole;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var procedureName = "spDeleteUserGroupRoles";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);

            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<UserGroupRole>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<UserGroupRole>> GetAllAsync()
        {
            var procedureName = "EXECUTE spGetAllUserGroupRoles";
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryAsync<UserGroupRole>(procedureName);
                return result.ToList();
            }
        }

        public async Task<UserGroupRole> GetByIdAsync(Guid id)
        {
            var procedureName = "spGetByIdUserGroupRoles";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);

            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<UserGroupRole>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<UserGroupRole> UpdateAsync(UpdateUserGroupRoleDto entity, Guid id)
        {
            var procedureName = "spUpdateUserGroupRoles";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("GroupId", entity.GroupId, DbType.Guid, ParameterDirection.Input);
            parameters.Add("RoleId", entity.RoleId, DbType.Guid, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.String, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<UserGroupRole>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var sserGroupRole = new UserGroupRole()
                {
                    UserId = id,
                    GroupId = entity.GroupId,
                    RoleId = entity.RoleId,
                    IsActive = entity.IsActive,


                };
                return sserGroupRole;
            }
        }
    }
}
