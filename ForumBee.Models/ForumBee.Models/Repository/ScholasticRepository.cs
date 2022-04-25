using Dapper;
using ForumITUDA.Models.Dto;
using ForumITUDA.Models.Entities;
using ForumITUDA.Models.Interface;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ForumITUDA.Models.Repository
{
    public class ScholasticRepository : IScholasticRepository
    {
        private readonly IConfiguration configuration;
        public ScholasticRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<Scholastic> AddAsync(CreateScholasticDto entity)
        {
            var procedureName = "spCreateScholastic";
            var parameters = new DynamicParameters();
            parameters.Add("Name", entity.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("SortOrder", entity.SortOrder, DbType.Int64, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.String, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Report>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var scholastic = new Scholastic()
                {
                    Name = entity.Name,
                    SortOrder = entity.SortOrder,
                    IsActive = entity.IsActive,
                };
                return scholastic;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var procedureName = "spDeleteScholastic";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);

            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Scholastic>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Scholastic>> GetAllAsync()
        {
            var procedureName = "EXECUTE spGetAllScholastic";
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryAsync<Scholastic>(procedureName);
                return result.ToList();
            }
        }

        public async Task<Scholastic> GetByIdAsync(Guid id)
        {
            var procedureName = "spGetByIdScholastic";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);

            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Scholastic>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<Scholastic> UpdateAsync(UpdateScholasticDto entity, Guid id)
        {
            var procedureName = "spUpdateScholastic";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("Name", entity.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("SortOrder", entity.SortOrder, DbType.Int64, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.String, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Scholastic>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var scholastic = new Scholastic()
                {
                    Id = id,
                    Name = entity.Name,
                    SortOrder = entity.SortOrder,
                    IsActive = entity.IsActive,


                };
                return scholastic;
            }
        }
    }
}
