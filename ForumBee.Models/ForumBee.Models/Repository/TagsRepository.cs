using Dapper;
using ForumITUDA.Models.Dto;
using ForumITUDA.Models.Entities;
using ForumITUDA.Models.Interface;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ForumITUDA.Models.Repository
{
    public class TagsRepository : ITagsRepository
    {
        private readonly IConfiguration configuration;
        public TagsRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<Tag> AddAsync(CreateTagDto entity)
        {
            var procedureName = "spCreateTags";
            var parameters = new DynamicParameters();
            parameters.Add("Name", entity.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("Slug", entity.Slug, DbType.String, ParameterDirection.Input);
            parameters.Add("Description", entity.Description, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Icon", entity.Icon, DbType.Guid, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.Boolean, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Tag>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var tag = new Tag()
                {
                    Name = entity.Name,
                    Slug = entity.Slug,
                    Description = entity.Description,
                    Icon = entity.Icon,
                    IsActive = entity.IsActive,

                };
                return tag;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var procedureName = "spDeleteTags";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);

            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Tag>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            var procedureName = "EXECUTE spGetAllTags";
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryAsync<Tag>(procedureName);
                return result.ToList();
            }
        }

        public async Task<Tag> GetByIdAsync(Guid id)
        {
            var procedureName = "spGetByIdTags";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);

            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Tag>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<Tag> UpdateAsync(UpdateTagDto entity, Guid id)
        {
            var procedureName = "spUpdateTags";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("Name", entity.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("Slug", entity.Slug, DbType.String, ParameterDirection.Input);
            parameters.Add("Description", entity.Description, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Icon", entity.Icon, DbType.Guid, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.Boolean, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Tag>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var tag = new Tag()
                {
                    Id = id,
                    Name = entity.Name,
                    Slug = entity.Slug,
                    Description = entity.Description,
                    Icon = entity.Icon,
                    IsActive = entity.IsActive,

                };
                return tag;
            }
        }
    }
}
