using Dapper;
using ForumITUDA.Models.Dto;
using ForumITUDA.Models.Entities;
using ForumITUDA.Models.Interface;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ForumITUDA.Models.Repository
{
    public class ReportsRepository : IReportsRepository
    {
        private readonly IConfiguration configuration;
        public ReportsRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<Report> AddAsync(CreateReportDto entity)
        {
            var procedureName = "spCreateReports";
            var parameters = new DynamicParameters();
            parameters.Add("Title", entity.Title, DbType.String, ParameterDirection.Input);
            parameters.Add("Content", entity.Content, DbType.String, ParameterDirection.Input);
            parameters.Add("WorkingStatus", entity.WorkingStatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("QuestionId", entity.QuestionId, DbType.Guid, ParameterDirection.Input);
            parameters.Add("CommentId", entity.CommentId, DbType.Guid, ParameterDirection.Input);
            parameters.Add("AnswerId", entity.AnswerId, DbType.Guid, ParameterDirection.Input);
            parameters.Add("CreatedBy", entity.CreatedBy, DbType.Guid, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.Boolean, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Report>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var report = new Report()
                {
                    Title = entity.Title,
                    Content = entity.Content,
                    WorkingStatus = entity.WorkingStatus,
                    QuestionId = entity.QuestionId,
                    CommentId = entity.CommentId,
                    AnswerId = entity.AnswerId,
                    CreatedBy = entity.CreatedBy,
                    IsActive = entity.IsActive,

                };
                return report;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var procedureName = "spDeleteReports";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);

            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Report>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Report>> GetAllAsync()
        {
            var procedureName = "EXECUTE spGetAllReports";
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryAsync<Report>(procedureName);
                return result.ToList();
            }
        }

        public async Task<Report> GetByIdAsync(Guid id)
        {
            var procedureName = "spGetByIdReports";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
          
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Report>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
               
                return result;
            }
        }

        public async Task<Report> UpdateAsync(UpdateReportDto entity, Guid id)
        {
            var procedureName = "spUpdateReports";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("Title", entity.Title, DbType.String, ParameterDirection.Input);
            parameters.Add("Content", entity.Content, DbType.String, ParameterDirection.Input);
            parameters.Add("WorkingStatus", entity.WorkingStatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("QuestionId", entity.QuestionId, DbType.Guid, ParameterDirection.Input);
            parameters.Add("CommentId", entity.CommentId, DbType.Guid, ParameterDirection.Input);
            parameters.Add("AnswerId", entity.AnswerId, DbType.Guid, ParameterDirection.Input);
            parameters.Add("CreatedBy", entity.CreatedBy, DbType.Guid, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.Boolean, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Report>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var report = new Report()
                {   
                    Id = id,
                    Title = entity.Title,
                    Content = entity.Content,
                    WorkingStatus = entity.WorkingStatus,
                    QuestionId = entity.QuestionId,
                    CommentId = entity.CommentId,
                    AnswerId = entity.AnswerId,
                    CreatedBy = entity.CreatedBy,
                    IsActive = entity.IsActive,

                };
                return report;
            }
        }
    }
}
