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
    public class AnswerVoteRepository : IAnswerVoteRepository
    {
        private readonly IConfiguration configuration;
        public AnswerVoteRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<AnswerVote> AddAsync(CreateAnswerVoteDto entity)
        {
            var procedureName = "spCreateAnswerVote";
            var parameters = new DynamicParameters();
            parameters.Add("IdAnswer", entity.IdAnswer, DbType.Guid, ParameterDirection.Input);
            parameters.Add("IdUser", entity.IdUser, DbType.Guid, ParameterDirection.Input);
            parameters.Add("Type", entity.Type, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.Boolean, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<AnswerVote>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var answerVote = new AnswerVote()
                {
                    IdAnswer = entity.IdAnswer,
                    IdUser = entity.IdUser,
                    Type = entity.Type,
                    IsActive = entity.IsActive,
                };
                return answerVote;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var procedureName = "spDeleteAnswerVote";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<AnswerVote>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<AnswerVote>> GetAllAsync()
        {
            var procedureName = "EXECUTE spGetAllAnswerVote";
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryAsync<AnswerVote>(procedureName);
                return result.ToList();
            }
        }

        public async Task<AnswerVote> GetByIdAsync(Guid id)
        {
            var procedureName = "spGetByIdAnswerVote";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<AnswerVote>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<AnswerVote> UpdateAsync(UpdateAnswerVoteDto entity, Guid id)
        {
            var procedureName = "spUpdateAnswerVote";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("IdAnswer", entity.IdAnswer, DbType.Guid, ParameterDirection.Input);
            parameters.Add("IdUser", entity.IdUser, DbType.Guid, ParameterDirection.Input);
            parameters.Add("Type", entity.Type, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("IsActive", entity.IsActive, DbType.Boolean, ParameterDirection.Input);
            using (var connection = new SqlConnection(configuration.GetConnectionString("ConnectionString")))
            {
                var result = await connection.QueryFirstOrDefaultAsync<AnswerVote>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                var answerVote = new AnswerVote()
                {
                    Id = id,
                    IdAnswer = entity.IdAnswer,
                    IdUser = entity.IdUser,
                    Type = entity.Type,
                    IsActive = entity.IsActive,
                };
                return answerVote;
            }
        }
    }
}
