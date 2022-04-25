using Dapper;
using ForumITUDA.Models.Dto;
using ForumITUDA.Models.Entities;
using ForumITUDA.Models.Interface;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ForumITUDA.Models.Repository
{
    public class RolesRepository : IRolesRepository
    {
        private readonly IConfiguration configuration;
        public RolesRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<Role> AddAsync(CreateRoleDto entity)
        {
            var procedureName = "spCreateRoles";
            var parameters = new DynamicParameters();
            parameters.Add("Name", entity.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("Description", entity.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.String, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Role>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var role = new Role()
                {
                   Name = entity.Name,
                   Description = entity.Description,
                   IsActive = entity.IsActive,
                };
                return role;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var procedureName = "spDeleteRoles";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);

            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Role>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            var procedureName = "EXECUTE spGetAllRoles";
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryAsync<Role>(procedureName);
                return result.ToList();
            }
        }

        public async Task<Role> GetByIdAsync(Guid id)
        {
            var procedureName = "spGetByIdRoles";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);

            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Role>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<Role> UpdateAsync(UpdateRoleDto entity, Guid id)
        {
            var procedureName = "spUpdateRoles";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("Name", entity.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("Description", entity.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.String, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Role>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var role = new Role()
                {
                    Id = id,
                    Name = entity.Name,
                    Description = entity.Description,
                    IsActive = entity.IsActive,
                  

                };
                return role;
            }
        }
    }
}
