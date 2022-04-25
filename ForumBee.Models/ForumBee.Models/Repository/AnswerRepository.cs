using Dapper;
using ForumITUDA.Models.Dto;
using ForumITUDA.Models.Entities;
using ForumITUDA.Models.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumITUDA.Models.Repository
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly IConfiguration configuration;
        public AnswerRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<Answer> AddAsync(CreateAnswerDto entity)
        {
            var procedureName = "spCreateAnswers";
            var parameters = new DynamicParameters();
            parameters.Add("QuestionId", entity.QuestionId, DbType.String, ParameterDirection.Input);
            parameters.Add("Content", entity.Content, DbType.String, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.Boolean, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Answer>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var answer = new Answer()
                {
                    QuestionId = entity.QuestionId,
                    Content = entity.Content,
                    IsActive = entity.IsActive
                };
                return answer;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var procedureName = "spDeleteAnswers";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Answer>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Answer>> GetAllAsync()
        {
            var procedureName = "EXECUTE spGetAllAnswers";
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryAsync<Answer>(procedureName);
                return result.ToList();
            }
        }

        public async Task<Answer> GetByIdAsync(Guid id)
        {
            var procedureName = "spGetByIdAnswers";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Answer>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<Answer> UpdateAsync(UpdateAnswerDto entity, Guid id)
        {
            var procedureName = "spUpdateAnswers";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("QuestionId", entity.QuestionId, DbType.String, ParameterDirection.Input);
            parameters.Add("Content", entity.Content, DbType.String, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.Boolean, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Answer>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var answer = new Answer()
                {
                    Id = id,
                    QuestionId = entity.QuestionId,
                    Content = entity.Content,
                    IsActive = entity.IsActive,
                };
                return answer;
            }
        }

        
    }
}
